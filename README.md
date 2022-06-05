# profBlogger
*Please note: This is not an actual product. Its only for project example use case. Some parts can be used personally but It's best not use the whole project for benefitial use. You wouldn't learn that way.*

This is a breif overview of my project. How I come think of problems and how I come up with a solution. From the System Design standpoint to Development
### System Design

A good example when it comes to System Design is to **Keep It Simple**. With my example of "profBlogger", I could show examples of how I am currently designing this project. The Basics.

### 1. The concept 

What comes to my mind is: "What are the basic actions a user should be
able to use, when it comes to using a bloglers' website?". The other is to always think in a High end user usage stand point ,as one of the importance of System design is *Scalability* at least keeping it basic.


<img src="https://github.com/Jerick-Molina/profBlogger/blob/development/images(Readme)/concept.png" width="50%" height="50%">

### 2. Endpoints
There's two types of EndPoints:

1. Public Endpoints
	- The methods the user is able to call when Authorized
2. Inner Endpoints
	- Methods that cannot be modified in any way by the user (Backend) 


<img src="https://github.com/Jerick-Molina/profBlogger/blob/development/images(Readme)/Endpoints.png" width="50%" height="50%">

### 3. The Database

A NoSQL Mongo Db would be used for this project due to its fast 
document data base using Horizontable scale-out architecture.

<img src="https://github.com/Jerick-Molina/profBlogger/blob/development/images(Readme)/db.png" width="50%" height="50%">
