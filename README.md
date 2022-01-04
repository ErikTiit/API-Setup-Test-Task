# API Task

Your task is to

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


## Other notes

Along with code submit instructions how to start the application.

No database setup is necessary, it is fine to hold data only as long as the application is
running.

Any other endpoints, which are not laid out in the spec should also be tested.