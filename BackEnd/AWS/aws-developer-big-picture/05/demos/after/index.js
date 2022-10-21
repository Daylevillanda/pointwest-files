const AWS = require('aws-sdk');

AWS.config.update({region: 'us-east-1'});

const dynamodb = new AWS.DynamoDB();

const item = {
  Item: {
    id: {
      S: (new Date()).getTime().toString()
    },
    value: {
      S: process.argv[2]
    }
  },
  TableName: 'aws-developer'
};

dynamodb.putItem(item, (err, res) => {
  if (err) throw err;
});