@echo off
protoc -I=protobuf protobuf\greeting_service.proto^
    --csharp_out=csharp^
    --grpc_out=csharp^
    --plugin=protoc-gen-grpc=tools/grpc_csharp_plugin.exe