This is a brief overview of my project. How I come think of problems and how I come up with a solution. From the System Design standpoint to Development
### System Design.

A good example when it comes to System Design is to **Keep It Simple**. With my example of "profBlogger", I could show examples of how I am currently designing this project. The Basics.

### 1. The concept 

What comes to my mind is: "What are the basic actions a user should be
able to use, when it comes to using a bloggers' website?". The other is to always think in a High end user usage stand point ,as one of the importance of System design is *Scalability* at least keeping it basic.

<img src="https://github.com/Jerick-Molina/profBlogger/blob/development/images(Readme)/concept.png" width="50%" height="50%">
### 2. Endpoints
There're two types of EndPoints:

1. Public Endpoints
	- The methods the user is able to call when Authorized
2. Inner Endpoints
	- Methods that cannot be modified in any way by the user (Backend) 


<img src="https://github.com/Jerick-Molina/profBlogger/blob/development/images(Readme)/Endpoints.png" width="50%" height="50%">

### 3. The Database

A No SQL Mongo Db would be used for this project due to its fast 
document data base using Horizon table scale-out architecture.

<img src="https://github.com/Jerick-Molina/profBlogger/blob/development/images(Readme)/db.png" width="50%" height="50%">

### 4 .The Diagram
<img src="https://github.com/Jerick-Molina/profBlogger/blob/development/images(Readme)/Diagram.png" width="50%" height="50%">

First Step would be the user Request to the *API Management* where the *API Management* would decide first if the user is Authenticated, if so it would then decide either the request is to write or to read.

- Write: The write server would then write to the database.
- Read: The *API Management* would go through a Load Balancer to decide what's the best route to decrease latency. Then the read server would check if the request is in the *Redis cache*. If not it would look through the MongoDB and return the results.

Reason why write server is simple is because the app is more focused on read than write. Most users would be reading rather than writing.
