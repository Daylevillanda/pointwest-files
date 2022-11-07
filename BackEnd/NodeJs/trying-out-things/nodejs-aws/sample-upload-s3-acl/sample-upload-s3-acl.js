// Create service client module using ES6 syntax.
import { S3Client, PutObjectCommand, GetObjectCommand } from "@aws-sdk/client-s3";
import { getSignedUrl } from "@aws-sdk/s3-request-presigner";
// Set the AWS Region.
const REGION = "ap-southeast-1";
// Create an Amazon S3 service client object.
const s3Client = new S3Client({ region: REGION });

let putBucketParams = {
    Bucket : 'awsnodejstraining',
    Key: `chester-dayle-mikko/sample-signed-url-v3.txt`,
    Body: "some text",
    
};

const command = new PutObjectCommand(putBucketParams);
console.log(await s3Client.send(command))
const getcommand = new GetObjectCommand(putBucketParams);
const signedUrl = await getSignedUrl(s3Client, getcommand, {
expiresIn: 3600
});
console.log(
`\nPutting "${putBucketParams.Key}" using signedUrl with body "${putBucketParams.Body}" in v3`
);
console.log(signedUrl);