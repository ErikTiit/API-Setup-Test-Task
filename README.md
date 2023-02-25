# API-Setup-Test-Task
Väike kodutöö


INSTALLATION GUIDE
------------------------------------------------
Nodejs v16 
Visual Studio 2022 And Visual studio Code
Yarn for installing and running the tests 
------------------------------------------------
RUNNING THE TESTS
------------------------------------------------
Visual studio 2022 to run the API --> API-Setup-Test-Task.sln
Visual studio Code to run the tests --> car.spec.js
Currently its required to use the command "export NODE_TLS_REJECT_UNAUTHORIZED=0;" to disable Node from rejecting the Self signed SSL certificate 
due to the website lacking an actual certificate - I am aware this is not an ideal way of overcoming this bug and can introduce extreme vulnerabilities.
------------------------------------------------
SIDE NOTE 
------------------------------------------------
The last test is an additional to wipe the database due to the inability to change the VIN number which acts as a primary key.
Ive tried the tests on 2 different MacOS Ventura 13.1 operating systems and a windows 11 operating systen and they worked everytime.
