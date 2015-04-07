using System;
using System.Collections.Generic;
using System.Configuration;
using System.Web.Profile;
using NUnit.Framework;
using NUnit.Framework.Constraints;

namespace DgonDotNet.Blog.Samples.AspNetProfiles
{
	public class ProfileTestProvider : ProfileProvider
	{
		private static readonly ProfileInfoCollection _emptyInfo = new ProfileInfoCollection();

		public override SettingsPropertyValueCollection GetPropertyValues(SettingsContext context, SettingsPropertyCollection collection)
		{
			return mergeCollections(collection, Properties);
		}

		public override void SetPropertyValues(SettingsContext context, SettingsPropertyValueCollection collection)
		{
			Properties = collection;
		}

		public override string ApplicationName { get; set; }
		public override int DeleteProfiles(ProfileInfoCollection profiles)
		{
			return 0;
		}

		public override int DeleteProfiles(string[] usernames)
		{
			return 0;
		}

		public override int DeleteInactiveProfiles(ProfileAuthenticationOption authenticationOption, DateTime userInactiveSinceDate)
		{
			return 0;
		}

		public override int GetNumberOfInactiveProfiles(ProfileAuthenticationOption authenticationOption, DateTime userInactiveSinceDate)
		{
			return 0;
		}

		public override ProfileInfoCollection GetAllProfiles(ProfileAuthenticationOption authenticationOption, int pageIndex, int pageSize, out int totalRecords)
		{
			totalRecords = 0;
			return _emptyInfo;
		}

		public override ProfileInfoCollection GetAllInactiveProfiles(ProfileAuthenticationOption authenticationOption, DateTime userInactiveSinceDate, int pageIndex, int pageSize, out int totalRecords)
		{
			totalRecords = 0;
			return _emptyInfo;
		}

		public override ProfileInfoCollection FindProfilesByUserName(ProfileAuthenticationOption authenticationOption, string usernameToMatch, int pageIndex, int pageSize, out int totalRecords)
		{
			totalRecords = 0;
			return _emptyInfo;
		}

		public override ProfileInfoCollection FindInactiveProfilesByUserName(ProfileAuthenticationOption authenticationOption, string usernameToMatch, DateTime userInactiveSinceDate, int pageIndex, int pageSize, out int totalRecords)
		{
			totalRecords = 0;
			return _emptyInfo;
		}

		public SettingsPropertyValueCollection Properties { get; set; }

		public void AssertPropertyValue(string propertyName, Constraint constraint)
		{
			SettingsPropertyValue p = Properties[propertyName];
			Assert.That(p.PropertyValue, constraint);
		}

		public void StubValues(params KeyValuePair<string, object>[] values)
		{
			Properties = new SettingsPropertyValueCollection();

			foreach (var pair in values)
			{
				Type type = pair.Value != null ? pair.Value.GetType() : typeof(object);
				var settings = new SettingsProperty(pair.Key, type, null, false, defaultOf(type),
					SettingsSerializeAs.ProviderSpecific, null, false, false);

				var settingsValue = new SettingsPropertyValue(settings) { PropertyValue = pair.Value };
				Properties.Add(settingsValue);
			}
		}

		private static SettingsPropertyValueCollection mergeCollections(SettingsPropertyCollection noValues, SettingsPropertyValueCollection withValues)
		{
			SettingsPropertyValueCollection merged = new SettingsPropertyValueCollection();
			foreach (SettingsProperty property in noValues)
			{
				var setting = new SettingsPropertyValue(property);
				if (withValues != null && withValues[property.Name] != null && withValues[property.Name].PropertyValue != null)
				{
					setting.PropertyValue = withValues[property.Name].PropertyValue;
				}
				merged.Add(setting);
			}

			return merged;
		}

		private static object defaultOf(Type t)
		{
			if (!t.IsValueType) return null;
			return Activator.CreateInstance(t);
		}
	}
}
