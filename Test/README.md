1.API URL function did not work for me so I manually entered the url into the fetch function.

2.If the port for the LocalHost changes , it is necessary to edit the port numbers for each test.

3.I ran the WEB API in Visual Studio 2022 and the test alongside in Visual Studio Code, it may be possible to run both in Visual Studio Code through further configuration but I am not sure.

4.Due to fetch not allowing Self-signed SSL certificate , I used this command in the terminal to bypass the error temporarily :"export NODE_TLS_REJECT_UNAUTHORIZED=0;" 
I am aware that this is not an optimal way of solving this problem and can pose risks of man-in-the-middle attacks. 

5.I modified the Tests a bit as well and added a further Delete method at the end to wipe the database due to how ASP .NET database behaves with Primary Keys and modifying them. Removal of that final wipe will throw an error at the "multiple car test" due to the cars already existing in the database.

