const AWS = require("aws-sdk");

const serverless = require("serverless-http");
const express = require("express");
const app = express();

const USERS_TABLE = "users-table-dev";
const dynamoDbClient = new AWS.DynamoDB.DocumentClient();

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
