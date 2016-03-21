# Manifest Desk Data Sample Client

This is a small sample tool written in Java to show how the Manifest Desk Data API can be used. The code has inline comments that help you understand every step of the way.

## Compiling the project

This project is built with Maven and all dependences will be taken care of. To compile this project, simply execute:

```mvn compile```

This project generates the REST Java client sources from RAML using a tool. This tool is not available in a Maven repository and needs to be downloaded and installed locally. The following section explains this.

## Generating client from RAML

This project uses a generator to generate the Java client from the RAML definition. The RAML definition and examples where downloaded from here: https://anypoint.mulesoft.com/apiplatform/marcura-2/#/portals/organizations/88010c78-4cb2-4b65-a41a-66a4bf489975/apis/54237/versions/56232/pages/70709

To generate the classes automatically, you will first need to download and install in your maven repository this project:

https://github.com/mulesoft-labs/raml-java-client-generator

Once you download, simply:

```mvn install -DskipTests```

## Using Database

Since this tool is just an example, it does not use a database. It simply downloads all the data from the API and stores this in Java Lists. Searching for HSCodes, Sanctions or Mappings require a search through the list. 

This job will be made much easier if the downloaded data is inserted in a database, and a simple SQL statement is used to figure out whether there are any sanctions.

If a database is used, the data downlad and database update can be done once per day as a scheduled task. The data will be updated by Manifest Desk daily.
