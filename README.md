
# FamilyTreeApi

An ASP.NET Core Web API for managing family tree records using a local JSON file. The project is containerized with Docker and deployed manually to AWS Elastic Beanstalk.

---

## 🧱 Project Structure

```
FamilyTreeApi/
├── Controllers/           
│   └── PeopleController.cs
├── Data/                  
│   ├── IPersonRepository.cs
│   └── PersonRepository.cs
├── Enums/               
│   └── Gender.cs
├── Middleware/           
│   └── ClientIdMiddleware.cs
├── Models/                
│   ├── Person.cs
│   └── PersonDto.cs
├── Services/               
│   └── PeopleService.cs
├── publish/                
├── appsettings.json      
├── appsettings.Development.json
├── people.json             
├── Dockerfile             
├── deploy.sh              
├── deploy.zip          
├── FamilyTreeApi.csproj
├── Program.cs
└── token.txt            
```

---

## ▶️ Running the Project Locally

### Option 1: Using .NET CLI

```bash
dotnet restore
dotnet run
```

API will be available at: `http://localhost:5000`

> Note: Ensure that `people.json` is present in the root directory.

---

### Option 2: Using Docker

 ```bash
dotnet publish -c Release -o publish
cp Dockerfile people.json publish/
cd publish
 docker build -t familytree-api .
 docker run -p 8080:5000 familytree-api
 ```
Access to the api :
http://localhost:8080/api/people

Remember to add the respective header to the call : x-client-id



---

## 🚀 Deployment to AWS Elastic Beanstalk

### Steps:

1. Execute the command :

```bash
./deploy.sh
```

2. This will generate a deploy.zip file

3. Go to AWS Elastic Beanstalk Console:
   - Create/select a Docker environment.
   - Upload and deploy the new `deploy.zip` package.

---

## 📂 Notes
- Make sure the app listens on port **5000** for compatibility with Beanstalk.

