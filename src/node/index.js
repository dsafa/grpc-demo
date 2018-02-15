const grpc = require("grpc");
const servicePath = __dirname + "/../protobuf/greeting_service.proto";
const greetingServiceDescriptor = grpc.load(servicePath).service_demo.GreetingService;

function sayHi(call, callback) {
    const name = call.request;
    console.log("Got request from " + name.first_name);

    let greeting = {
        name: name,
        greeting_type: "MORNING",
    }

    callback(null, greeting);
}

let server = new grpc.Server();
server.addService(greetingServiceDescriptor.service, {
    sayHi: sayHi
});
server.bind("0.0.0.0:6789", grpc.ServerCredentials.createInsecure());
server.start();
console.log("Server started");