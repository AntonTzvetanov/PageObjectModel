using System;
using System.Collections.Generic;
using System.Text;

namespace POM
{
   public static class UserFactory 
    {
        public static RegistrationUser LoginUser()
        {
            return new RegistrationUser
            {

                FirstName = "TonyCvetanov",

                LastName = "test",
                
                Password = "somePassword",

                Year = "1988",

                Month = "6",

                Day = "13",

                RealFirstName = "TestUser",

                RealLastName = "Testov",

                Company = "MyCompany",

                Address = "MyAddress",

                AddresLine2 = "MySecondAddress",

                City = "Sofia",

                State = "Alabama",

                Country = "United States",

                HomePfone = "00000000",

                MobilePhone = "0011111",

                Allias = "AlliasAddress",

                PostCode = "00000",

            };



        }


    }
    

}
