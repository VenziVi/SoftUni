﻿using BasicWebServer.Server.Common;
using System.Text;

namespace BasicWebServer.Server.HTTP
{
    public class ContentResponse : Response

    {
        public ContentResponse(string _content, string _contentType,
            Action<Request, Response> _preRenderAction = null) 
            : base(StatusCode.OK)
        {
            Guard.AgainstNull(_content);
            Guard.AgainstNull(_contentType);

            PreRenderAction = _preRenderAction;
            Headers.Add(Header.ContentType, _contentType);

            Body = _content;
        }

        public override string ToString()
        {
            if (Body != null)
            {
                var contentLength = Encoding.UTF8.GetByteCount(Body).ToString();
                Headers.Add(Header.ContentLength, contentLength);
            }

            return base.ToString();
        }
    }
}