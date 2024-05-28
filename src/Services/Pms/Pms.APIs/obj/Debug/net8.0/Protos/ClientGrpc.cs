// <auto-generated>
//     Generated by the protocol buffer compiler.  DO NOT EDIT!
//     source: Protos/client.proto
// </auto-generated>
#pragma warning disable 0414, 1591, 8981, 0612
#region Designer generated code

using grpc = global::Grpc.Core;

namespace Pms.APIs.Protos {
  public static partial class ClientService
  {
    static readonly string __ServiceName = "ClientService";

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static void __Helper_SerializeMessage(global::Google.Protobuf.IMessage message, grpc::SerializationContext context)
    {
      #if !GRPC_DISABLE_PROTOBUF_BUFFER_SERIALIZATION
      if (message is global::Google.Protobuf.IBufferMessage)
      {
        context.SetPayloadLength(message.CalculateSize());
        global::Google.Protobuf.MessageExtensions.WriteTo(message, context.GetBufferWriter());
        context.Complete();
        return;
      }
      #endif
      context.Complete(global::Google.Protobuf.MessageExtensions.ToByteArray(message));
    }

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static class __Helper_MessageCache<T>
    {
      public static readonly bool IsBufferMessage = global::System.Reflection.IntrospectionExtensions.GetTypeInfo(typeof(global::Google.Protobuf.IBufferMessage)).IsAssignableFrom(typeof(T));
    }

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static T __Helper_DeserializeMessage<T>(grpc::DeserializationContext context, global::Google.Protobuf.MessageParser<T> parser) where T : global::Google.Protobuf.IMessage<T>
    {
      #if !GRPC_DISABLE_PROTOBUF_BUFFER_SERIALIZATION
      if (__Helper_MessageCache<T>.IsBufferMessage)
      {
        return parser.ParseFrom(context.PayloadAsReadOnlySequence());
      }
      #endif
      return parser.ParseFrom(context.PayloadAsNewBuffer());
    }

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::Pms.APIs.Protos.registerClientRequest> __Marshaller_registerClientRequest = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::Pms.APIs.Protos.registerClientRequest.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::Pms.APIs.Protos.registerClientResponse> __Marshaller_registerClientResponse = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::Pms.APIs.Protos.registerClientResponse.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::Pms.APIs.Protos.updateCredentialRequest> __Marshaller_updateCredentialRequest = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::Pms.APIs.Protos.updateCredentialRequest.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::Pms.APIs.Protos.updateCredentialResponse> __Marshaller_updateCredentialResponse = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::Pms.APIs.Protos.updateCredentialResponse.Parser));

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Method<global::Pms.APIs.Protos.registerClientRequest, global::Pms.APIs.Protos.registerClientResponse> __Method_RegisterClient = new grpc::Method<global::Pms.APIs.Protos.registerClientRequest, global::Pms.APIs.Protos.registerClientResponse>(
        grpc::MethodType.Unary,
        __ServiceName,
        "RegisterClient",
        __Marshaller_registerClientRequest,
        __Marshaller_registerClientResponse);

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Method<global::Pms.APIs.Protos.updateCredentialRequest, global::Pms.APIs.Protos.updateCredentialResponse> __Method_UpdateKarizCredential = new grpc::Method<global::Pms.APIs.Protos.updateCredentialRequest, global::Pms.APIs.Protos.updateCredentialResponse>(
        grpc::MethodType.Unary,
        __ServiceName,
        "UpdateKarizCredential",
        __Marshaller_updateCredentialRequest,
        __Marshaller_updateCredentialResponse);

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Method<global::Pms.APIs.Protos.updateCredentialRequest, global::Pms.APIs.Protos.updateCredentialResponse> __Method_UpdateDpkCredential = new grpc::Method<global::Pms.APIs.Protos.updateCredentialRequest, global::Pms.APIs.Protos.updateCredentialResponse>(
        grpc::MethodType.Unary,
        __ServiceName,
        "UpdateDpkCredential",
        __Marshaller_updateCredentialRequest,
        __Marshaller_updateCredentialResponse);

    /// <summary>Service descriptor</summary>
    public static global::Google.Protobuf.Reflection.ServiceDescriptor Descriptor
    {
      get { return global::Pms.APIs.Protos.ClientReflection.Descriptor.Services[0]; }
    }

    /// <summary>Base class for server-side implementations of ClientService</summary>
    [grpc::BindServiceMethod(typeof(ClientService), "BindService")]
    public abstract partial class ClientServiceBase
    {
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::System.Threading.Tasks.Task<global::Pms.APIs.Protos.registerClientResponse> RegisterClient(global::Pms.APIs.Protos.registerClientRequest request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::System.Threading.Tasks.Task<global::Pms.APIs.Protos.updateCredentialResponse> UpdateKarizCredential(global::Pms.APIs.Protos.updateCredentialRequest request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::System.Threading.Tasks.Task<global::Pms.APIs.Protos.updateCredentialResponse> UpdateDpkCredential(global::Pms.APIs.Protos.updateCredentialRequest request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

    }

    /// <summary>Creates service definition that can be registered with a server</summary>
    /// <param name="serviceImpl">An object implementing the server-side handling logic.</param>
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    public static grpc::ServerServiceDefinition BindService(ClientServiceBase serviceImpl)
    {
      return grpc::ServerServiceDefinition.CreateBuilder()
          .AddMethod(__Method_RegisterClient, serviceImpl.RegisterClient)
          .AddMethod(__Method_UpdateKarizCredential, serviceImpl.UpdateKarizCredential)
          .AddMethod(__Method_UpdateDpkCredential, serviceImpl.UpdateDpkCredential).Build();
    }

    /// <summary>Register service method with a service binder with or without implementation. Useful when customizing the service binding logic.
    /// Note: this method is part of an experimental API that can change or be removed without any prior notice.</summary>
    /// <param name="serviceBinder">Service methods will be bound by calling <c>AddMethod</c> on this object.</param>
    /// <param name="serviceImpl">An object implementing the server-side handling logic.</param>
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    public static void BindService(grpc::ServiceBinderBase serviceBinder, ClientServiceBase serviceImpl)
    {
      serviceBinder.AddMethod(__Method_RegisterClient, serviceImpl == null ? null : new grpc::UnaryServerMethod<global::Pms.APIs.Protos.registerClientRequest, global::Pms.APIs.Protos.registerClientResponse>(serviceImpl.RegisterClient));
      serviceBinder.AddMethod(__Method_UpdateKarizCredential, serviceImpl == null ? null : new grpc::UnaryServerMethod<global::Pms.APIs.Protos.updateCredentialRequest, global::Pms.APIs.Protos.updateCredentialResponse>(serviceImpl.UpdateKarizCredential));
      serviceBinder.AddMethod(__Method_UpdateDpkCredential, serviceImpl == null ? null : new grpc::UnaryServerMethod<global::Pms.APIs.Protos.updateCredentialRequest, global::Pms.APIs.Protos.updateCredentialResponse>(serviceImpl.UpdateDpkCredential));
    }

  }
}
#endregion
