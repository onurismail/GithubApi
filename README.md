# GithubApi
Simple Get exercise to retreive data from Github API with .net Core


The goal of this exercise is to write a HTTP service with the following specs:
Given a city name (e.g. Barcelona) the service should return a list of the top contributors (number of commits by the user). 
The results must be sorted by the number of repositories published by the user in GitHub.

https://developer.github.com/

<h3>Project</h3>

<b>Used Technologies</b>

<ul>
    <li>API REST with <b>.NET Core 2</b><br>For SDK: <a href="https://www.microsoft.com/net/download/core">https://www.microsoft.com/net/download/core</a></li>
    <li>C# with Visual Studio 2017</li>
    <li>Swagger for testing the endpoint</li>
</ul>

<h3>API method endpoint usage and parameters</h3>

<pre>
    <b>location</b> : String, can be any city
    
    <b>sort</b> : Sorts the results of your query by number of followers or repositories, 
    or when the person joined GitHub. Default: best match
    
    <b>order</b> : Determines whether the first search result returned is the highest number of matches (desc)
    or lowest number of matches (asc). This parameter is ignored unless you provide sort. Default: desc
    
    <b>https://localhost:_your_port_/api/transactions?location=barcelona&sort=repositories&order=asc</b>
</pre>  

<h3>Response</h3>
The response of the application is in JSON string format 

<h3>Future Improvements</h3>
