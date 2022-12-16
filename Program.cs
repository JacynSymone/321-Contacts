namespace Three2OneContact {
    internal class Program {
        struct Contact {
            public string firstName;
            public string lastName;
            public string address;
            public string city;
            public string state;
            public string zipCode;
            public string title;
        }//End Struct 
        static void Main(string[] args) {
            //Variables             
            int userSelection = -1;

                     
           while(userSelection != 0) {
               userSelection = Menu();
               
               switch (userSelection) {
                   case 1: { SearchMode() ; break; };
                   case 2: { AddMode(); break; };
                   default: { Console.WriteLine("Thank you for using my search engine"); break; }
               
          
               }//End menu selection switch decision
          
                if (userSelection != 0) {
                    Input("Press enter to go back to the menu");
                }//End if statement
          
           }//End while loop
         
        }//End Main

    static string Input(string prompt) {
            Console.Write(prompt + ": ");
            return Console.ReadLine();
        }//End Function

        static int Menu() {
            bool parsing = false;
            string userInput = "";
            int userSelection;

            do {
                Console.Clear();
                Console.WriteLine("Make a selection from the menu\n" +
                    "Press '0' to exit program\n");

                Header("321 Contacts");
                Console.WriteLine();
                Console.WriteLine("1: Search Mode");
                Console.WriteLine("2: Add Mode");

                userInput = Input("Program Selection");
                parsing = int.TryParse(userInput, out userSelection);
            } while (parsing == false || userSelection <0 || userSelection > 3);

            return userSelection;

        }//End Menu
        public static void Header(string title, string subtitle = "") {
            Console.Clear();
            Console.WriteLine();
            int windowWidth = 90 - 2;
            string titleContent = String.Format("\t    ║{0," + ((windowWidth / 2) + (title.Length / 2)) + "}{1," + (windowWidth - (windowWidth / 2) - (title.Length / 2) + 1) + "}", title, "║");
            string subtitleContent = String.Format("\t    ║{0," + ((windowWidth / 2) + (subtitle.Length / 2)) + "}{1," + (windowWidth - (windowWidth / 2) - (subtitle.Length / 2) + 1) + "}", subtitle, "║");



            Console.WriteLine("\t    ╔════════════════════════════════════════════════════════════════════════════════════════╗");
            Console.WriteLine(titleContent);
            if (!string.IsNullOrEmpty(subtitle)) {
                Console.WriteLine(subtitleContent);
            }
            Console.WriteLine("\t    ╚════════════════════════════════════════════════════════════════════════════════════════╝");
        }//End Header function (Thank you NATHAN)



        static string ReadFile() {
            //Create variable to hold file
            string path = @"C:\Users\jacyn\Downloads\contacts.dat";
            string data = "";
            //Create variable to read file 
            StreamReader infile = new StreamReader(path);

            //While loop that reads the file by line
            while(infile.EndOfStream == false) {
                data = infile.ReadLine();                             
            }//End while loop where file is being read one line at a time

            infile.Close();//This saves and closes the file
           
            return data;
        }//End ReadLine Function

        static void SearchMode() {
           
            //Create string variable and assign the ReadFile function into it so the information inside may be used later as a string
            string data = ReadFile();

            //Create an array of strings and fill it with the string "data". Split the contact records using  a record separator. Cast number to a char
            string[] records = data.Split((char)30);

            //Create an array (of the instance) of struct type "Contact". 
            //Inside of contactInfo[] make a new array of the struct Contact and assign the arrays size to the size of records[] minus one
            Contact[] contactInfo = new Contact[records.Length - 1 ];

            for (int recordNumber = 0; recordNumber < contactInfo.Length; recordNumber++) {
                //Get a record
                string currentRecord = records[recordNumber];

                //Split the Record
                string[] fields = currentRecord.Split((char)31);

                //Store to contact Struct [firstName, lastName, address, city, state, zipCode, title]
                contactInfo[recordNumber].firstName = fields[0];
                contactInfo[recordNumber].lastName = fields[1];
                contactInfo[recordNumber].address = fields[2];
                contactInfo[recordNumber].city = fields[3];
                contactInfo[recordNumber].state = fields[4];
                contactInfo[recordNumber].zipCode = fields[5];
                contactInfo[recordNumber].title = fields[6];

            }//end for loop

            //Variables
            int size = contactInfo.Length;
            String name = "";

            do {
                Console.Clear();//
                //Take in input
                name = Input("Search name");
                Console.WriteLine("");


                 //For loop that runs through the index of Contact[] contactInfo
                 for (int index = 0; index < size; index++) {
                     // make a new variable and fill it with the indices of Contact info to show the current contact 
                     Contact currentContact = contactInfo[index];

                     if (currentContact.firstName.ToLower().Contains(name.ToLower()) || currentContact.lastName.ToLower().Contains(name.ToLower())) {

                         Console.WriteLine($"Name: {currentContact.title} {currentContact.firstName} {currentContact.lastName}\n" +
                             $"Address: {currentContact.address}\n" +
                             $"{currentContact.city}, {currentContact.state}, {currentContact.zipCode}\n ");

                     }//End if decision

                 }// End for loop

            } while (Input("Search again (y/n)") == "y");
            Console.Clear();
             
        }//End Fucntion

        static void AddMode() {
            Console.Clear();
            //Writing to a file
            //Declare StreamWriter 
            StreamWriter outfile = new StreamWriter (@"C:\Users\jacyn\Downloads\contacts.dat",true);//add true so the file doesnt delete and replace all the info
                       
            do {

                string title = (Input("Enter title"));
                Console.Clear();
                string firstName = (Input("Please enter first name"));
                Console.Clear();
                string lastName = (Input("Please enter last name"));
                Console.Clear();
                string address = (Input("Please enter address"));
                Console.Clear();
                string city = (Input("Please enter city"));
                Console.Clear();
                string state = (Input("Please enter state"));
                Console.Clear();
                string zipCode = (Input("Please enter zipcode")); 
                Console.Clear();


                outfile.Write(firstName);
                outfile.Write((char)31);
                outfile.Write(lastName);
                outfile.Write((char)31);
                outfile.Write(address);
                outfile.Write((char)31);
                outfile.Write(city);
                outfile.Write((char)31);
                outfile.Write(state);
                outfile.Write((char)31);
                outfile.Write(zipCode);
                outfile.Write((char)31);
                outfile.Write(title);
                outfile.Write((char)30);

            }while (Input("Add another contact (y/n)") == "y");

            outfile.Close();

        }//End Add Mode function

    }//end class
}//End Namespace