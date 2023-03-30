# EventsApp 
# How to Download And Start the Application:
1. Download the zip file from this repository ( Make sure you have installed Visual Studio with all the packages needed to run a .net application)
2. Open the .sln file
3. When the project opens, in the header click the Tools button, then NuGet Package Manager, then Package Manager Console. 
![image](https://user-images.githubusercontent.com/93039914/228835755-aa8f1322-c80c-4075-90ac-9ccaa9f0c513.png)

3.1 Please check first that you have the packages needed for this project, so your EventsApp -> Dependencies -> Packages should look like this : 
![image](https://user-images.githubusercontent.com/93039914/228834685-15abaa9c-527f-4dcb-ac32-9e4d6cd9e385.png)

4. When the console opens, it should look like this 

![image](https://user-images.githubusercontent.com/93039914/228834800-50b7ac4f-6dc4-45b9-9c68-c063b3e081cd.png)

5. In order to start the database into your local system, you need to run : Add-Migration <Name> Like this ![image](https://user-images.githubusercontent.com/93039914/228834956-4e203f25-0a64-4a31-9f1b-f0c4624ad094.png)
6. It should print build succeded. After that, you need to update the database, so we run Update-Database ![image](https://user-images.githubusercontent.com/93039914/228835254-34a9352f-3380-4673-9e7b-2f657f0caa6f.png)
7. It should generate a lot of SQL QUERY's, and after that, if you did not see any red texts, you're good to go. It should look like this : ![image](https://user-images.githubusercontent.com/93039914/228835455-56368465-87e2-494f-adeb-a77b6ce544f2.png)
8. After that, you need to run the application, so you need to go and click on this button ![image](https://user-images.githubusercontent.com/93039914/228835560-105473dd-73fb-41f6-84a8-6105a321786c.png)
9. Now your application should start working and this is the end of the setup. I hope you did not find any problems.

# How to perform administrative task, from a non developer perspective :
In order to perform any tasks possible on the website, which are : creating a new event, deleting and editing an existing event, you need to open the application.
1. When the application Starts, it should look like this : 

![image](https://user-images.githubusercontent.com/93039914/228836478-a4cc8d93-9991-4544-95c7-7bd9737c7764.png)

1.1 If it doesn't look like this, you probably need to log in, so this should appear right? 

![image](https://user-images.githubusercontent.com/93039914/228836688-a826d1a2-79ab-4def-bc44-b8987baf4240.png)

1.2 In order to log in so you can use the app, you can enter with the following account : Username : user@test.com , password : User1! You could aswell register a new account if you like.
2. Now that you are logged in, and you see the home page with the events, here are how you can do any of your desired interactions
Create a new Event: Go to the homepage, in the header, you need to select Add Event

![image](https://user-images.githubusercontent.com/93039914/228837518-9903d87a-2d49-4a16-9369-3be0fe7aef6e.png)

And there you need to write all the fields needed. 
Edit an existing event : In order to edit an existign event, you need to click on show event 

![image](https://user-images.githubusercontent.com/93039914/228837706-cdbe3e09-899d-46f3-8cd1-8b4d84376b01.png)

And then, click on Edit.

In order to delete an event, you need to do the same steps as in the editing process, but just select delete instead of Edit. Be carefull, if you select delete, the event
will be instantly deleted!

# How the application works and how to continue it from a developer perspective 
In this part I am going to explain how to continue working with the application and what features it has so far. 
The Design/Arhitectural pattern is MVC, and so this project is using .net MVC 6, with Entity and Identity Framework, and with mySQL Database that's integrated into the IDE.
The Search and Load More Functions of the website are done VIA AJAX. In total, the features of the website are : CRUD on events, auto-generating on start 25 random events so it can be tested.
A search bar that searches through the database and filters based on the Title. The elements shown are in descending order by their start date. If you do not give any input into the 
SearchBar then an error it's going to pop up, and if you type something, and there are more then 5 results, the application will only show you 5, and at the bottom you are going to have a button 
called "Load More" That loads 5 or less events that matches the search string given. This feature is also done via AJAX. This is how it works : In the EventsController you have the controller
where all the methods are created and executed, in Models you have the models of the application, in this given context being Event and Tag. Every event has
1. Id
2. Title
3. Content
4. StartDate
5.EndDate
6.Link
7. A Tag ( this is done via selecting the id tag and then you're assiging the right tagname coresponding to that id) 
Every Tag model has :
1. Id 
2. TagName

In application Db context we have Every Model in our DataBase, and what we are going to create a table for.(ApplicationDbContext is inside Data). So if you want to add another model
you need to add it here as well. Don't forget, if you change anything into the DataBase you need to Run Add-Migration <Name> , Update-Database.
Next, in the Model Folder we have the SeedData folder, here are the things we generate into our database. Here we have 2 accounts, a user and an admin, and 25 events, but also 3 tags.
And now, in the Views, we have the pages. Here are our scripts using AJAX and jQuery. 
Now i'm going to explain how they work : 
# Search Script

![image](https://user-images.githubusercontent.com/93039914/228840906-4fb30c80-f3d8-4840-95a1-a29ffc0f8211.png)

So, here, we are initially setting the page to 1, that means, we did not press any load_more until now, ( we want to reset this page everytime we type something different
because if we did not do this, if we pressed on a given page the load button 4 times, then here we would be at page 4, and we do not want that. 
After that, we put a trigger on the #searchBtn item, and when we click it, we reset the page to 1, we get the value in the textbox, and if it is null, we are going to print out an error
because it is mandatory to have input into the textbox if you want to search something, so we make the searcherror element to show, (inittially it was hidden).
If we have input into the text box, we start AJAX and define the type of action, ours being GET, because we want go GET something, and then we set the route of the action.
Because are our actions are done VIA the EventsController, we are going to give the name of the controller, and the method that applies the search filter. So, Events/Results
data : means what parameters are we passing into the function, in our case, we are passing the search string, so we know considering what to filter the items.

Now going back to the Method: 

![image](https://user-images.githubusercontent.com/93039914/228842613-8797d5aa-3e81-4490-9e41-cf129d4c930e.png)

So here, we select all events, and after that, if the search string is not null, we select only the first 5, ordered by their start date, that containt that search
string into their title, and we transform that into a list. After that, we Go intro our partialView, Called _EventList. 

![image](https://user-images.githubusercontent.com/93039914/228843117-48e4cc1d-f356-485b-baee-eeed94489b87.png)

Here, because we passed our model to this View, we can use it to acces all the objects in our list. So we iterate through all with foreach, and we show the atributtes.
Down there we have 2 buttons, a show event button, that redirects you to a page to only view the current event, and a visit their page website. The Show event redirects us
into another method into the EventsController, called Show(id), and that's why we write it that way. 

# Load More Script 

Now we are going to explain the load more feature. This feature is using AJAX and jQuery to select the next 5 events that matches the search string given, and if there are not more then 5 events, we hide the button. We are going to start with the AJAX script

![image](https://user-images.githubusercontent.com/93039914/228844244-c6a2a2b4-5cac-4f7a-98ca-1dacf1972f6e.png)

So here, we select the button with the class loadMoreBtn, and, we put a trigger on it when we click it. When we click it, we increment the page number (so we know what pages to show, because all the time we are appending the next 5 elements, by multiplying our page with our nr of pages, so page * 5. After that, we go into our route with Events and LoadMore method, with 2 given parameters, page, and #search().val() that gives us the value inside the search box. We then type the action we are doing, which is GET. Let's now go into our Load More Method inside our controller. 

![image](https://user-images.githubusercontent.com/93039914/228844833-d902679b-9e7f-4529-a281-b72f4c24a403.png)


So here, we set our page size to 5 ( because that how many events we want to show next). We passed the page number and search strng arguments, and now we are going to  do a query to get all the events that matches the searc string, but we skip the first page*5, because we already have that on our list of events showed on the page.
We do that using Skip, which skips the first n elements of a list, and then we take the next 5 using Take() method, and we transform that into a list. If they are no events anymore, we return a NotFound(); If it succeded, we go again inside our PartialView so we can show the next 5.


![image](https://user-images.githubusercontent.com/93039914/228845442-3cfe414e-f27c-4fe7-8a03-64da03b03d7d.png)


Let's look again at what happens after we comeback from the function with a succes. After we come back, we check if your response if less than 5, and if it is , we are going to hide the load more button because we they are not anymore events to load, and we append the data. If your output is 5, then that means that we still have events, so we keep the button to be shown.

# Time Sheet
- 3/29/2023 13:00:00 PM - > First Look on the project and the required features
- 3/29/2023 13:30:00 PM - > Finished the start setup, like connecting the database, adding the users and so on
- 3/29/2023 17:00:00 PM -> From 13:30 until 17:00 i had a break.
- 3/29/2023 18:30:00 PM -> Finished the search ajax function, but it still had a few bugs
- 3/29/2023 20:00:00 PM -> Finished the Load More Ajax function, still with a few bugs
- 3/30/2023 10:00:00 AM -> Did not do any work until 10:00 am the next morning
- 3/30/2023 11:00:00 AM -> Finished and solved all bugs for the Load More Ajax Function and Search, also added CRUD on Events and did some styling of the application.
- 3/30/2023 15:00:00 PM -> Started working towards the Documentation, did not work until 15:00.
- 3/30/2023 16:17:00 PM -> Here i am right now, finished the Documentation.

# Bugs During the development
1.  Because i did not reset the page while pressing the load more button, after i've pressed the load more button until we did not have any more events on a page, the page counter would remain the same, and when i typed something differently, it would skip the number of times i've pressed the load more button
2. Could not hide the load more button, and if i did hide it, when i've  gone to another page it would not appear again because i did not reset it in the search script.




