using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace CSharpCollections.TestDataVaraibales
{
    class CsvReaderList
	{
		private string _csvFilePath;

		public CsvReaderList(string csvFilePath)
		{
			this._csvFilePath = csvFilePath;
		}

		public List<Country> ReadAllCountries()
		{
			List<Country> countries = new List<Country>();

			using (StreamReader sr = new StreamReader(_csvFilePath))
			{
				// read header line
				sr.ReadLine();

				string csvLine = sr.ReadLine();

				while ((csvLine = sr.ReadLine()) != null)
				{
					countries.Add(ReadCountryFromCsvLine(csvLine));
				}
			}

			return countries;
		}

		public Dictionary<string, List<Country>> ReadAllCountriesBasedOnRegion()
		{
			var countries = new Dictionary<string, List<Country>>();

			using (StreamReader sr = new StreamReader(_csvFilePath))
			{
				// read header line
				sr.ReadLine();

				string csvLine = sr.ReadLine();

				while ((csvLine = sr.ReadLine()) != null)
				{
					Country country = ReadCountryFromCsvLine(csvLine);

					if (countries.ContainsKey(country.Region))
					{
						countries[country.Region].Add(country);
                    }
                    else
                    {
						List<Country> countriesInRegion = new List<Country>() { country };
						countries.Add(country.Region, countriesInRegion);
                    }
				}
			}
			return countries;
		}

		public List<Country> ReadFirstNCountries()
		{
			List<Country> countries = new List<Country>();

			using (StreamReader sr = new StreamReader(_csvFilePath))
			{
				// read header line
				sr.ReadLine();

				string csvLine = sr.ReadLine();

				while((csvLine = sr.ReadLine()) != null)
                {
					countries.Add(ReadCountryFromCsvLine(csvLine));
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


		public void RemoveCommaCountries(List<Country> countries)
        {
			for (int i = countries.Count; i >= 0; i--)
            {
				if (countries[i].Name.Contains(','))
                {
					countries.RemoveAt(i);
                }
            }
        }

		public void RemoveCommaCountriesOptimized(List<Country> countries)
		{
			countries.RemoveAll(country => country.Name.Contains(','));
		}
	}
}
