#!/bin/bash
dotnet build
coverlet ./OnixWebApiTest/bin/Debug/netcoreapp3.0/OnixWebApiTest.dll --target "dotnet" --targetargs "test . --no-build" --format lcov
