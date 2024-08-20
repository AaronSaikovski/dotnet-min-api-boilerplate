/*
MIT License

# Copyright (c) 2024 Aaron Saikovski

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.
*/

using Asp.Versioning.Builder;
namespace minapi.boilerplate.endpoints;

internal sealed class PingEndpoint : IRegisterEndpoint
{
    //Ref: https://blog.treblle.com/how-to-structure-your-minimal-api-in-net/
    
   /// <summary>
   /// 
   /// </summary>
   /// <param name="app"></param>
   /// <param name="versionSet"></param>
   public static void RegisterEndpoint(IEndpointRouteBuilder app, ApiVersionSet versionSet)
    {        
        // get  http://localhost:<PORT>/api/ping?api-version=1.0
        //Ping -> Pong
        app.MapGet("/api/ping", () =>
                "pong-v1"
            )
            .WithApiVersionSet(versionSet)
            .MapToApiVersion(1.0)
            .WithName("ping-v1")
            .WithOpenApi();


        // get  http://localhost:<PORT>>/api/ping?api-version=2.0
        app.MapGet("/api/ping", () =>
                "pong-v2"
            )
            .WithApiVersionSet(versionSet)
            .MapToApiVersion(2.0)
            .WithName("ping-v2")
            .WithOpenApi();

    }
}