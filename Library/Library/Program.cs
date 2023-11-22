using Library;

CD cd = new CD();
Console.WriteLine("CD");
cd.name = "Encore";
cd.genre = "Rap";
cd.price = 7.99;
cd.author = "Eminem";
cd.audioLength = 5340;
cd.displayLibrary();
cd.displayCD();

Console.WriteLine("");

Book book = new Book();
Console.WriteLine("Book");
book.name = "The Great Gatsby";
book.genre = "Tragedy";
book.price = 3.99;
book.author = "F. Scott Fitzgerald";
book.wordCount = 47097;
book.displayLibrary();
book.displayBook();


