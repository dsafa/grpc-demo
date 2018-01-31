@echo off
protoc protobuf\greeting.proto^
    --csharp_out=csharp^
    --js_out=import_style=commonjs:node^
    --python_out=python