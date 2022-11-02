const AWS = require("aws-sdk");
const jwt = require("jsonwebtoken")
const { CognitoJwtVerifier } = require("aws-jwt-verify");

const serverless = require("serverless-http");
const express = require("express");
const app = express();

let options = {};
if (process.env.IS_OFFLINE) {
  options = {
    region: 'localhost',
    endpoint: 'http://localhost:8000',
  };
}

const USERS_TABLE = "flexben";
const dynamoDbClient = new AWS.DynamoDB.DocumentClient(options);

const verifier = CognitoJwtVerifier.create({
  userPoolId: "us-east-1_kKRSmZZw5",
  tokenUse: "access",
  clientId: "1hnpp06ioej14lf72rib0k2lc8",
});

app.use(express.json());

app.get("/users", async function (req, res) {
  const params = {
    TableName: USERS_TABLE
  };

  try {
    const data = await dynamoDbClient.scan(params).promise();
    if (data.ScannedCount > 0) {
      res.status(200).json(data);
    } else {
      res
        .status(200)
        .json({ message: 'No Content' });
    }
  } catch (error) {
    console.log(error);
    res.status(500).json({ error: "Could not retreive users" });
  }
});

app.post("/login", async (req, res, next) => {
  const token  = req.body.token
  let details = {}
  try {
    const payload = await verifier.verify(token);
    details = payload
    response = "Token is valid";
  } catch {
    response = "Token not valid!";
  }
  return res.status(200).json({
    message: response,
    payload: details
  });
});

app.get("/", (req, res, next) => {
  return res.status(200).json({
    message: "Hello from root!",
  });
});

app.get("/hello", (req, res, next) => {
  return res.status(200).json({
    message: "Hello from path!",
  });
});

app.use((req, res, next) => {
  return res.status(404).json({
    error: "Not Found",
  });
});

module.exports.handler = serverless(app);
