# CIS4327: Senior Project - Pre-Semester Assignment
IgniteVMS is a Volunteer Management System created as a sort of warm-up project before starting work on our actual Senior Project.

**Professor:** Karthikeyan Umapathy

**Group Members:**
- David Rojas Gonzalez
- Fernando Jimenez Mendez
- Jonathan D. Depaul
- Lucas Graeff

# Project Management Resources
- [Trello Board](https://trello.com/b/O6iIRvlr): Kanban board for task management purposes
- [dbdiagram.io diagram](https://dbdiagram.io/d/60e8d22d7e498c3bb3f02679): A reference ERD of our database.

# Running Locally
## You'll need:
- Visual Studio 2019
- Yarn

## Back-end only
If you're running the application to work on the back-end and you don't care about launching the site on your browser, all you need to do is run the dotnet project with VS.

## Front-end
If you're going to work on the front-end, you'll need to run the dotnet solution with Visual Studio and open a terminal inside the `/src/IgniteVMS.Client/` directory. Once the terminal is open, run `yarn` to install all the required npm packages and lastly run `yarn start` to build the front-end with webpack and watch for changes.
