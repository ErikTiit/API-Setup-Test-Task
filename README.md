# API Task

Your task is to:

1. write a small (REST) API, which follows the specs outlaid in tests
of this repository.

2. Ammend the tests (and your application code) in a way that every rerun of the tests
will reproduce same results without restarting the application.

## Tests setup

1. Install latest Node (at least Node v16)

2. Install packages with `yarn install`

## Running tests

On Linux

`API_URL="YOUR_APPLICATION_URL_GOES_HERE" yarn test`

On Windows cmd (Command Prompt)

```cmd
setx API_URL "YOUR_APPLICATION_URL_GOES_HERE"
yarn test
```

## Submission

1. Fork this repository

2. Solve task laid out by tests. Commit code.

3. Send a link to your public repository via e-mail.

## Evaluation

Your submission will be evaluated in the following categories:

- Adherence to the specs laid out in tests

- Quality of the code: [Clean code rules](https://gist.github.com/wojteklu/73c6914cc446146b8b533c0988cf8d29)

- Git practices and commit message quality: [How to write a good commit message](https://www.gitkraken.com/learn/git/best-practices/git-commit-message)

## Other notes

You are free to use whatever language/framework/technologies you want.

Along with code submit instructions how to start the application.

No database setup is necessary, it is fine to hold data only as long as the application is
running (in RAM).

Example solution can be found at: [API Setup test task example](https://github.com/Foundation-CR14/API-Setup-test-task-example)
