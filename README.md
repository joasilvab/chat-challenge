# Financial chat challenge
This project in its entirety consists of 4 parts:    
The **ChatApi** (this repository)  
The **ChatApp**, that is the Angular app for the Financial chat, that make requests to the **ChatApi**. https://github.com/joasilvab/chat-app  
The **ChatBot**, that gets requests and execute commands https://github.com/joasilvab/chat-bot  
The **ChatIdentity**, an implementation of IdentityServer 4 (with "in-memory" data) https://github.com/joasilvab/chat-identity

## Prerequisites
You'll need to have installed Node.js (https://nodejs.org/es/) needed for the Angular app, and RabbitMQ (https://www.rabbitmq.com/install-windows-manual.html) installed as a service (it may not be mandatory to be a service). **ChatApi** subscribes to a message queue in order to recieve messages, while **ChatBot** acts as a message emitter. **ChatApi**, **ChatBot** and the RabbitMQ service, need to be executed on the same server, as for now it is hardcoded to comunicate to "localhost".

## Running the challenge
**ChatApi**, **ChatBot** and **ChatIdentity**, can all be ran by executing "dotnet run" on the windows command prompt, or ran them through Visual Studio 2019. For **ChatApp**, you need to download the code, change directory to where the "package.json" is located, and execute "npm install". Once it is done installing the required dependencies, execute "npm start", and you'll be able to browse to the app at "http://localhost:4200"
