using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace CSharpCollections.TestDataVaraibales
{
    class CsvReaderDictionary
	{
		private string _csvFilePath;

		public CsvReaderDictionary(string csvFilePath)
		{
			this._csvFilePath = csvFilePath;
		}

		public Dictionary<string, Country> ReadCountries()
		{
			Dictionary<string,Country> countries = new Dictionary<string, Country>();

			using (StreamReader sr = new StreamReader(_csvFilePath))
			{
				// read header line
				sr.ReadLine();

				string csvLine = sr.ReadLine();

				while((csvLine = sr.ReadLine()) != null)
                {
					var country = ReadCountryFromCsvLine(csvLine);
					countries.Add(country.Code, country);
				}				
			}

			return countries;
		}

		public Country ReadCountryFromCsvLine(string csvLine)
		{
			string[] parts = csvLine.Split(new char[] { ',' });

			string name;
			string code;
			string region;
			string poptext;

            switch (parts.Length)
            {
				case 4:
					name = parts[0];
					code = parts[1];
					region = parts[2];
					poptext = parts[3];
					break;
				case 5:
					name = parts[0] + ", " + parts[1];
					code = parts[2];
					region = parts[3];
					poptext = parts[4];
					break;
				default:
					throw new Exception($"Can't parse country from csvLine: {csvLine}");
            }
			int.TryParse(poptext, out int population);
			return new Country(name, code, region, population);
		}
	}
}
