# Zencoder

The class library for interacting with the API on [Zencoder](http://zencoder.com).

See [http://zencoder.com/docs/api](http://zencoder.com/docs/api) for more details on the API.

## Getting Started

Download or build zencoder-dotnet.dll, add it to your project and create a reference.

Add "**using ZencoderDotNet;**" / "**using ZencoderDotNet.Api;**" to the top of any .cs files using the library.

## Job Creation

Create a json or xml string with the information for the job you want processed, e.g:

JSON:
	@"{
	""api_key"": ""93h630j1dsyshjef620qlkavnmzui3"",
	""input"": ""s3://bucket-name/file-name.avi""
	}"

XML:
	@"&lt;api-request&gt;
	&lt;api_key&gt;93h630j1dsyshjef620qlkavnmzui3&lt;/api_key&gt;
	&lt;input&gt;s3://bucket-name/file-name.avi</input&gt;
	&lt;/api-request&gt;"




