/* 
 * Realtime Notification Service
 *
 * No description provided (generated by Swagger Codegen https://github.com/swagger-api/swagger-codegen)
 *
 * OpenAPI spec version: v1
 * 
 * Generated by: https://github.com/swagger-api/swagger-codegen.git
 */

using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.ComponentModel.DataAnnotations;
using SwaggerDateConverter = IO.Swagger.Client.SwaggerDateConverter;

namespace IO.Swagger.Model
{
    /// <summary>
    /// Realtime Notification Service Request
    /// </summary>
    [DataContract]
    public partial class EndpointGetRequest :  IEquatable<EndpointGetRequest>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EndpointGetRequest" /> class.
        /// </summary>
        /// <param name="Headers">Header information..</param>
        /// <param name="Body">Body.</param>
        public EndpointGetRequest(List<Header> Headers = default(List<Header>), RequestBody Body = default(RequestBody))
        {
            this.Headers = Headers;
            this.Body = Body;
        }
        
        /// <summary>
        /// Header information.
        /// </summary>
        /// <value>Header information.</value>
        [DataMember(Name="headers", EmitDefaultValue=false)]
        public List<Header> Headers { get; set; }

        /// <summary>
        /// Gets or Sets Body
        /// </summary>
        [DataMember(Name="body", EmitDefaultValue=false)]
        public RequestBody Body { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class EndpointGetRequest {\n");
            sb.Append("  Headers: ").Append(Headers).Append("\n");
            sb.Append("  Body: ").Append(Body).Append("\n");
            sb.Append("}\n");
            return sb.ToString();
        }
  
        /// <summary>
        /// Returns the JSON string presentation of the object
        /// </summary>
        /// <returns>JSON string presentation of the object</returns>
        public string ToJson()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented);
        }

        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="input">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object input)
        {
            return this.Equals(input as EndpointGetRequest);
        }

        /// <summary>
        /// Returns true if EndpointGetRequest instances are equal
        /// </summary>
        /// <param name="input">Instance of EndpointGetRequest to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(EndpointGetRequest input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.Headers == input.Headers ||
                    this.Headers != null &&
                    this.Headers.SequenceEqual(input.Headers)
                ) && 
                (
                    this.Body == input.Body ||
                    (this.Body != null &&
                    this.Body.Equals(input.Body))
                );
        }

        /// <summary>
        /// Gets the hash code
        /// </summary>
        /// <returns>Hash code</returns>
        public override int GetHashCode()
        {
            unchecked // Overflow is fine, just wrap
            {
                int hashCode = 41;
                if (this.Headers != null)
                    hashCode = hashCode * 59 + this.Headers.GetHashCode();
                if (this.Body != null)
                    hashCode = hashCode * 59 + this.Body.GetHashCode();
                return hashCode;
            }
        }

        /// <summary>
        /// To validate all properties of the instance
        /// </summary>
        /// <param name="validationContext">Validation context</param>
        /// <returns>Validation Result</returns>
        IEnumerable<System.ComponentModel.DataAnnotations.ValidationResult> IValidatableObject.Validate(ValidationContext validationContext)
        {
            yield break;
        }
    }

}
