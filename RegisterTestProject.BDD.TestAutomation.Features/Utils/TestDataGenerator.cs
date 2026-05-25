using System;

namespace RegisterTestProject.BDD.TestAutomation.Features.Utils
{
    public static class TestDataGenerator
    {
        private static readonly Random _random = new Random();

        private static readonly string[] FirstNames = 
        { 
            "John", "Jane", "Michael", "Sarah", "David", "Emma", "Robert", "Olivia", 
            "James", "Sophia", "William", "Ava", "Benjamin", "Isabella", "Lucas", "Mia" 
        };

        private static readonly string[] LastNames = 
        { 
            "Smith", "Johnson", "Williams", "Brown", "Jones", "Garcia", "Miller", "Davis", 
            "Rodriguez", "Martinez", "Hernandez", "Lopez", "Gonzalez", "Wilson", "Anderson", "Thomas" 
        };

        /// <summary>
        /// Generates a random first name.
        /// </summary>
        public static string GenerateFirstName()
        {
            return FirstNames[_random.Next(FirstNames.Length)];
        }

        /// <summary>
        /// Generates a random last name.
        /// </summary>
        public static string GenerateLastName()
        {
            return LastNames[_random.Next(LastNames.Length)];
        }

        /// <summary>
        /// Generates a random full name.
        /// </summary>
        public static string GenerateFullName()
        {
            return $"{GenerateFirstName()} {GenerateLastName()}";
        }

        /// <summary>
        /// Generates a random username based on first and last name.
        /// </summary>
        public static string GenerateUsername()
        {
            return $"{GenerateFirstName().ToLower()}{GenerateLastName().ToLower()}{_random.Next(1000, 9999)}";
        }

        /// <summary>
        /// Generates a random email address.
        /// </summary>
        public static string GenerateEmail()
        {
            return $"{GenerateUsername()}@example.com";
        }

        /// <summary>
        /// Generates a random phone number (US format).
        /// </summary>
        public static string GeneratePhoneNumber()
        {
            return $"555-{_random.Next(100, 999)}-{_random.Next(1000, 9999)}";
        }

        /// <summary>
        /// Generates a random SSN (for testing only, not real).
        /// </summary>
        public static string GenerateSSN()
        {
            return $"{_random.Next(100, 999)}-{_random.Next(10, 99)}-{_random.Next(1000, 9999)}";
        }

        /// <summary>
        /// Generates a random zip code.
        /// </summary>
        public static string GenerateZipCode()
        {
            return _random.Next(10000, 99999).ToString();
        }
    }
}
