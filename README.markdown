# Zencoder

The class library for interacting with the API on [Zencoder](http://zencoder.com).

See [http://zencoder.com/docs/api](http://zencoder.com/docs/api) for more details on the API.

## Getting Started

Download or build zencoder-dotnet.dll, add it to your project and create a reference.

Add "**using ZencoderDotNet;**" / "**using ZencoderDotNet.Api;**" to the top of any .cs files using the library.

## Job Creation

Create a json or xml string with the information for the job you want processed, e.g:

JSON:
	string json = @"{
	  ""api_key"": ""93h630j1dsyshjef620qlkavnmzui3"",
	  ""input"": ""s3://bucket-name/file-name.avi""
	}"

XML:
	string xml = @"<api-request>
	  <api_key>93h630j1dsyshjef620qlkavnmzui3</api_key>
	  <input>s3://bucket-name/file-name.avi</input>
	</api-request>"

Then call the create method of ZencoderDotNet.Api.Job with the format of the string:
	
	Job job = Job.create(json, "json")
or
	Job job = Job.create(xml, "xml")

This sends a request to the Zencoder API to create a new job, then deserializes the response from Zencoder into an instance of the Job class with some information about the job you created:

	job.test // true
	job.id // 12345
	job.outputs[0].url // s3://bucket-name/output-file-name.mp4


	




