FROM public.ecr.aws/lambda/dotnet:5.0

WORKDIR /var/task

# This COPY command copies the .NET Lambda project's build artifacts from the host machine into the image. 
# The source of the COPY should match where the .NET Lambda project publishes its build artifacts. If the Lambda function is being built 
# with the AWS .NET Lambda Tooling, the `--docker-host-build-output-dir` switch controls where the .NET Lambda project
# will be built. The .NET Lambda project templates default to having `--docker-host-build-output-dir`
# set in the aws-lambda-tools-defaults.json file to "bin/Release/net5.0/linux-x64/publish".
#
# Alternatively Docker multi-stage build could be used to build the .NET Lambda project inside the image.
# For more information on this approach checkout the project's README.md file.

RUN yum install -y unzip net-tools

# For testing...
RUN yum install -y net-tools iputils
ENV PATH="/usr/sbin:${PATH}"


# Install Chrome Driver
RUN cd /tmp/
RUN curl -O https://chromedriver.storage.googleapis.com/87.0.4280.88/chromedriver_linux64.zip
RUN unzip chromedriver_linux64.zip
RUN mv chromedriver /usr/bin/chromedriver

# Install Chrome
RUN curl -O https://dl.google.com/linux/direct/google-chrome-stable_current_x86_64.rpm
RUN yum install -y ./google-chrome-stable_current_*.rpm
# RUN curl -O https://dl.google.com/linux/direct/google-chrome-stable-87.0.4280.141-1.x86_64.rpm
# RUN yum install -y ./google-chrome-stable*.rpm
# RUN ls -l
# :87.0.4280.141-1
# RUN yum repolist

COPY "bin/Release/net5.0/linux-x64/publish"  .
