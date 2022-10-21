# sparrow
A lightweight shell for Twitter botmaking

Remember:
1. Don't put your API credentials in your source code
2. API credentials are sensitive info

## Setup Steps
Here are some things you should make sure are
done before working with this repository.

1. Install Python3 and Pip
    The latest version of Python 3 should have pip 
    installed by default so you likely have it 
    already! If you need help getting pip read 
    more here:
    http://pip.readthedocs.io/en/latest/installing/#install-pip

    This should be the case for all modern operating systems.

2. Install boto3
    If you don't have boto3 you can install it 
    with pip. This command should work:

    pip3 install boto3

    If you have any issues you can review the documentation here:
    https://boto3.readthedocs.io/en/latest/guide/quickstart.html

3. Install the AWS CLI V1
    If you don't have the AWS Command Line 
    Interface setup you can install it with pip. 
    One of these commands should work:

    pip install awscli

    sudo pip install awscli

    sudo pip install awscli --ignore-installed six

    If none of these commands work you can read
    more in the documentation here:
    http://docs.aws.amazon.com/cli/latest/userguide/installing.html

4. Get your AWS Access Keys
    Log into the aws console and follow these
    instructions:

    1. Go to https://console.aws.amazon.com/iam/home?#home
    2. Choose "Users"
    3. Choose your IAM username (not the check box)
    4. Choose the Security Credentials tab and 
    then choose Create Access Key.
    5. To see your access key, choose Show User 
    Security Credentials. Your credentials will 
    look something like this:

    Access Key ID: AKIAIOSFODNN7EXAMPLE
    Secret Access Key: wJalrXUtnFEMI/K7MDENG/bPxRfiCYEXAMPLEKEY

    6. Choose Download Credentials, and store 
    the keys in a secure location.

5. Configure the AWS CLI
    Once you have your access keys you can 
    configure the AWS CLI. 

    Open a shell and use this command:

    aws configure

    Follow the prompts and enter in your keys 
    and the region you are working in. You can
    see a list of regions and region codes here:
    http://docs.aws.amazon.com/AWSEC2/latest/UserGuide/using-regions-availability-zones.html#concepts-available-regions

    AWS Access Key ID [None]: AKIAIOSFODNN7EXAMPLE
    AWS Secret Access Key [None]: wJalrXUtnFEMI/K7MDENG/bPxRfiCYEXAMPLEKEY
    Default region name [None]: us-east-1
    Default output format [None]: ENTER

    You should now be ready to go with the AWS CLI

6. Twython
    You should be able to install Twython with:

    pip install twython

    But if you have any issues you can check the 
    documentation here: 
    https://twython.readthedocs.io/en/latest/usage/install.html