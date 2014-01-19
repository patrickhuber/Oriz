using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleXacml
{
    public static class Constants
    {
        private static readonly string Xacml = "urn:oasis:names:tc:xacml:";
        private static readonly string V1 = Xacml + "1.0:";
        private static readonly string V2 = Xacml + "2.0:";
        private static readonly string V3 = Xacml + "3.0:";

        public static class Attributes
        {
            private static readonly string Environment = V1 + "environment:";
            public static readonly string CurrentDate = Environment + "current-time";
            public static readonly string CurrentTime = Environment + "current-date";
            public static readonly string CurentDateTime = Environment + "current-dateTime";
        }

        public static class StatusCodes
        {
            private static readonly string Status = V1 + "status:";
            public static readonly string MissingAttribute = Status + "missing-attribute";
            public static readonly string Ok = Status + "ok";
            public static readonly string ProcessingError = Status + "processing-error";
            public static readonly string SyntaxError = Status + "syntax-error";
        }

        public static class Identifiers
        {
            public static class Subject
            {
                private static readonly string SubjectPrefix = V1 + "subject:";
                public static class AuthnLocality
                {
                    private static readonly string AuthnPrefix = SubjectPrefix + "authn-locality:";
                    public static readonly string DnsName = AuthnPrefix + "dns-name";
                    public static readonly string IpAddress = AuthnPrefix + "ip-address";
                }
                public static readonly string AuthenticationMethod = SubjectPrefix + ":authentication-method";
                public static readonly string AuthenticationTime = SubjectPrefix + ":authentication-time";
                public static readonly string SubjectId = SubjectPrefix + ":subject-id";
                public static readonly string SubjectIdQualifier = SubjectPrefix + ":subject-id-qualifier";
            }

            public static class SubjectCategory
            {
                private static readonly string SubjectCategoryPrefix = V1 + "subject-category:";
                public static readonly string AccessSubject = SubjectCategoryPrefix + "access-subject";
                public static readonly string Codebase = SubjectCategoryPrefix + "codebase";
                public static readonly string IntermediarySubject = SubjectCategoryPrefix + "intermediary-subject";
                public static readonly string RecepientSubject = SubjectCategoryPrefix + "recipient-subject";
                public static readonly string RequestingMachine = SubjectCategoryPrefix + "requesting-machine";
            }

            public static class Resource
            {
                private static readonly string ResourcePrefix = V1 + "resource:";
                public static readonly string ResourceLocation = ResourcePrefix + "resource-location";
                public static readonly string ResourceId = ResourcePrefix + "resource-id";
                public static readonly string SimpleFileName = ResourcePrefix + "simple-file-name";
            }

            public static class Action
            {
                private static readonly string ActionPrefix = V1 + "action:";
                public static readonly string ActionId = ActionPrefix + "action-id";
                public static readonly string ImpliedAction = ActionPrefix + "implied-action";
            }
        }

        public static class Functions
        {
            private static readonly string OasisNamespace = "urn:oasis:names:tc:xacml";
            private static readonly string Function = "function:";
            private static readonly string FunctionV1 = V1 + Function;
            private static readonly string FunctionV2 = V2 + Function;
            private static readonly string FunctionV3 = V3 + Function;

            public static readonly string AccessPermitted = FunctionV3 + "access-permitted";
            public static readonly string AllOf = FunctionV3 + "all-of";
            public static readonly string AllOfAll = FunctionV1 + "all-of-all";
            public static readonly string AllOfAny = FunctionV1 + "all-of-any";
            public static readonly string And = FunctionV1 + "and";
            public static readonly string AnyOf = FunctionV3 + "any-of";
            public static readonly string AnyOfAll = FunctionV1 + "any-of-all";
            public static readonly string AnyOfAny = FunctionV3 + "any-of-any";
            public static readonly string Floor = FunctionV1 + "floor";
            public static readonly string Map = FunctionV3 + "map";
            public static readonly string NOf = FunctionV1 + "n-of";
            public static readonly string Not = FunctionV1 + "not";
            public static readonly string Or = FunctionV1 + "or";
            public static readonly string Round = FunctionV1 + "round";

            public static class AnyUri
            {
                public static readonly string Bag = FunctionV1 + "-anyURI-bag";
                public static readonly string BagSize = FunctionV1 + "-anyURI-bag-size";
                public static readonly string IsIn = FunctionV1 + "-anyURI-is-in";
                public static readonly string OneAndOnly = FunctionV1 + "-anyURI-one-and-only";
                public static readonly string AtLeaseOneMemberOf = FunctionV1 + "-anyURI-at-least-one-member-of";
                public static readonly string Contains = FunctionV3 + "-anyURI-contains";
                public static readonly string EndsWith = FunctionV3 + "-anyURI-ends-with";
                public static readonly string Equal = FunctionV1 + "-anyURI-equal";
                public static readonly string FromString = FunctionV3 + "-anyURI-from-string";
                public static readonly string Intersection = FunctionV1 + "-anyURI-intersection";
                public static readonly string RegexpMatch = FunctionV2 + "-anyURI-regexp-match";
                public static readonly string SetEquals = FunctionV1 + "-anyURI-set-equals";
                public static readonly string StartsWith = FunctionV3 + "-anyURI-starts-with";
                public static readonly string Subset = FunctionV1 + "-anyURI-subset";
                public static readonly string Substring = FunctionV3 + "-anyURI-substring";
                public static readonly string Union = FunctionV1 + "-anyURI-union";
            }

            public static class Base64Binary
            {
                public static readonly string AtLeaseOneMemberOf = FunctionV1 + "base64Binary-at-least-one-member-of";
                public static readonly string Bag = FunctionV1 + "base64Binary-bag";
                public static readonly string BagSize = FunctionV1 + "base64Binary-bag-size";
                public static readonly string Intersection = FunctionV1 + "base64Binary-intersection";
                public static readonly string IsIn = FunctionV1 + "base64Binary-is-in";
                public static readonly string OneAndOnly = FunctionV1 + "base64Binary-one-and-only";
                public static readonly string SetEquals = FunctionV1 + "base64Binary-set-equals";
                public static readonly string Subset = FunctionV1 + "base64Binary-subset";
                public static readonly string Union = FunctionV1 + "base64Binary-union";
            }

            public static class Boolean
            {
                public static readonly string Equal = FunctionV1 + "bool-equal";
                public static readonly string AtLeastOneMemberOf = FunctionV1 + "boolean-at-least-one-member-of";
                public static readonly string Bag = FunctionV1 + "boolean-bag";
                public static readonly string BagSize = FunctionV1 + "boolean-bag-size";
                public static readonly string FromString = FunctionV3 + "boolean-from-string";
                public static readonly string Intesection = FunctionV1 + "boolean-intersection";
                public static readonly string IsIn = FunctionV1 + "boolean-is-in";
                public static readonly string OneAndOnly = FunctionV1 + "boolean-one-and-only";
                public static readonly string SetEquals = FunctionV1 + "boolean-set-equals";
                public static readonly string Subset = FunctionV1 + "boolean-subset";
                public static readonly string Union = FunctionV1 + "boolean-union";
            }

            public static class Date
            {
                public static readonly string AtLeaseOneMemberOf = FunctionV1 + "date-at-least-one-member-of";
                public static readonly string Bag = FunctionV1 + "date-bag";
                public static readonly string BagSize = FunctionV1 + "date-bag-size";
                public static readonly string Equal = FunctionV1 + "date-equal";
                public static readonly string FromString = FunctionV3 + "date-from-string";
                public static readonly string GreaterThan = FunctionV1 + "date-greater-than";
                public static readonly string GreaterThanOrEqual = GreaterThan + "-anyURI-or-equal";
                public static readonly string Intersection = FunctionV1 + "date-intersection";
                public static readonly string IsIn = FunctionV1 + "date-is-in";
                public static readonly string LessThan = FunctionV1 + "date-less-than";
                public static readonly string LessThanOrEqual = LessThan + "-anyURI-or-equal";
                public static readonly string OneAndOnly = FunctionV1 + "date-one-and-only";
                public static readonly string SetEquals = FunctionV1 + "date-set-equals";
                public static readonly string Subset = FunctionV1 + "date-subset";
                public static readonly string Union = FunctionV1 + "date-union";
            }
            public static class DateTime
            {
                public static readonly string AddDayTimeDuration = FunctionV3 + "dateTime-add-dayTimeDuration";
                public static readonly string AddYearMonthDuration = FunctionV3 + "dateTime-add-yearMonthDuration";
                public static readonly string AtLeaseOneMemberOf = FunctionV1 + "dateTime-at-least-one-member-of";
                public static readonly string Bag = FunctionV1 + "dateTime-bag";
                public static readonly string BagSize = FunctionV1 + "dateTime-bag-size";
                public static readonly string DurationBag = FunctionV3 + "dateTimeDuration-bag";
                public static readonly string DurationBagSize = FunctionV3 + "dateTimeDuration-bag-size";
                public static readonly string DurationIsIn = FunctionV3 + "dateTimeDuration-is-in";
                public static readonly string DurationOneAndOnly = FunctionV3 + "dateTimeDuration-one-and-only";
                public static readonly string Equal = FunctionV1 + "dateTime-equal";
                public static readonly string FromString = FunctionV3 + "dateTime-from-string";
                public static readonly string GreaterThan = FunctionV1 + "dateTime-greater-than";
                public static readonly string GreaterThanOrEqual = GreaterThan + "-anyURI-or-equal";
                public static readonly string Intersection = FunctionV1 + "dateTime-intersection";
                public static readonly string IsIn = FunctionV1 + "dateTime-is-in";
                public static readonly string LessThan = FunctionV1 + "dateTime-less-than";
                public static readonly string LessThanOrEqual = LessThan + "-anyURI-or-equal";
                public static readonly string OneAndOnly = FunctionV1 + "dateTime-one-and-only";
                public static readonly string SetEquals = FunctionV1 + "dateTime-set-equals";
                public static readonly string Subset = FunctionV1 + "dateTime-subset";
                public static readonly string SubtractDayTimeDuration = FunctionV3 + "dateTime-subtract-dayTimeDuration";
                public static readonly string SubtractYearMonthDuration = FunctionV3 + "dateTime-subtract-yearMonthDuration";
                public static readonly string Union = FunctionV1 + "dateTime-union";
            }
            public static class DayTimeDuration
            {
                public static readonly string AtLeaseOneMemberOf = FunctionV3 + "dayTimeDuration-at-least-one-member-of";
                public static readonly string Equal = FunctionV3 + "dayTimeDuration-equal";
                public static readonly string FromString = FunctionV3 + "dayTimeDuration-from-string";
                public static readonly string Intersection = FunctionV3 + "dayTimeDuration-intersection";
                public static readonly string SetEquals = FunctionV3 + "dayTimeDuration-set-equals";
                public static readonly string Subset = FunctionV3 + "dayTimeDuration-subset";
                public static readonly string Union = FunctionV3 + "dayTimeDuration-union";
            }

            public static class DnsName
            {
                public static readonly string Bag = FunctionV2 + "dnsName-bag";
                public static readonly string BagSize = FunctionV2 + "dnsName-bag-size";
                public static readonly string FromString = FunctionV3 + "dnsName-from-string";
                public static readonly string OneAndOnly = FunctionV2 + "dnsName-one-and-only";
                public static readonly string RegexpMatch = FunctionV2 + "dnsName-regexp-match";
            }

            public static class Double
            {
                public static readonly string Abs = FunctionV1 + "double-abs";
                public static readonly string Add = FunctionV1 + "double-add";
                public static readonly string AtLeaseOneMemberOf = FunctionV1 + "double-at-least-one-member-of";
                public static readonly string Bag = FunctionV1 + "double-bag";
                public static readonly string BagSize = FunctionV1 + "double-bag-size";
                public static readonly string Divide = FunctionV1 + "double-divide";
                public static readonly string Equal = FunctionV1 + "double-equal";
                public static readonly string FromString = FunctionV3 + "double-from-string";
                public static readonly string GreaterThan = FunctionV1 + "double-greater-than";
                public static readonly string GreaterThanOrEqual = GreaterThan + "-anyURI-or-equal";
                public static readonly string Intersection = FunctionV1 + "double-intersection";
                public static readonly string IsIn = FunctionV1 + "double-is-in";
                public static readonly string LessThan = FunctionV1 + "double-less-than";
                public static readonly string LessThanOrEqual = LessThan + "-anyURI-or-equal";
                public static readonly string Multiply = FunctionV1 + "double-multiply";
                public static readonly string OneAndOnly = FunctionV1 + "double-one-and-only";
                public static readonly string SetEquals = FunctionV1 + "double-set-equals";
                public static readonly string Subset = FunctionV1 + "double-subset";
                public static readonly string Subtract = FunctionV1 + "double-subtract";
                public static readonly string ToInteger = FunctionV1 + "double-to-integer";
                public static readonly string Union = FunctionV1 + "double-union";
            }

            public static class HexBinary
            {
                public static readonly string AtLeaseOneMemberOf = FunctionV1 + "hexBinary-at-least-one-member-of";
                public static readonly string Bag = FunctionV1 + "hexBinary-bag";
                public static readonly string BagSize = FunctionV1 + "hexBinary-bag-size";
                public static readonly string Equal = FunctionV1 + "hexBinary-equal";
                public static readonly string Intersection = FunctionV1 + "hexBinary-intersection";
                public static readonly string IsIn = FunctionV1 + "hexBinary-is-in";
                public static readonly string OneAndOnly = FunctionV1 + "hexBinary-one-and-only";
                public static readonly string SetEquals = FunctionV1 + "hexBinary-set-equals";
                public static readonly string Subset = FunctionV1 + "hexBinary-subset";
                public static readonly string Union = FunctionV1 + "hexBinary-union";
            }

            public static class Integer
            {
                public static readonly string SetEquals = FunctionV1 + "integer-set-equals";
                public static readonly string Abs = FunctionV1 + "integer-abs";
                public static readonly string Add = FunctionV1 + "integer-add";
                public static readonly string AtLeastOneMemberOf = FunctionV1 + "integer-at-least-one-member-of";
                public static readonly string Bag = FunctionV1 + "integer-bag";
                public static readonly string BagSize = FunctionV1 + "integer-bag-size";
                public static readonly string Divide = FunctionV1 + "integer-divide";
                public static readonly string Equal = FunctionV1 + "integer-equal";
                public static readonly string FromString = FunctionV3 + "integer-from-string";
                public static readonly string GreaterThan = FunctionV1 + "integer-greater-than";
                public static readonly string GreaterThanOrEqual = GreaterThan + "-anyURI-or-equal";
                public static readonly string Intersection = FunctionV1 + "integer-intersection";
                public static readonly string IsIn = FunctionV1 + "integer-is-in";
                public static readonly string LessThan = FunctionV1 + "integer-less-than";
                public static readonly string LessThanOrEqual = LessThan + "-anyURI-or-equal";
                public static readonly string Mod = FunctionV1 + "integer-mod";
                public static readonly string Multiply = FunctionV1 + "integer-multiply";
                public static readonly string OneAndOnly = FunctionV1 + "integer-one-and-only";
                public static readonly string Subset = FunctionV1 + "integer-subset";
                public static readonly string Subtract = FunctionV1 + "integer-subtract";
                public static readonly string ToDouble = FunctionV1 + "integer-to-double";
                public static readonly string Union = FunctionV1 + "integer-union";
            }

            public static class IpAddress
            {
                public static readonly string Bag = FunctionV2 + "ipAddress-bag";
                public static readonly string BagSize = FunctionV2 + "ipAddress-bag-size";
                public static readonly string FromString = FunctionV3 + "ipAddress-from-string";
                public static readonly string OneAndOnly = FunctionV2 + "ipAddress-one-and-only";
                public static readonly string RegexpMatch = FunctionV2 + "ipAddress-regexp-match";
            }

            public static class Rfc822Name
            {
                public static readonly string AtLeaseOneMemberOf = FunctionV1 + "rfc822Name-at-least-one-member-of";
                public static readonly string Bag = FunctionV1 + "rfc822Name-bag";
                public static readonly string BagSize = FunctionV1 + "rfc822Name-bag-size";
                public static readonly string Equal = FunctionV1 + "rfc822Name-equal";
                public static readonly string FromString = FunctionV3 + "rfc822Name-from-string";
                public static readonly string Intersection = FunctionV1 + "rfc822Name-intersection";
                public static readonly string IsIn = FunctionV1 + "rfc822Name-is-in";
                public static readonly string Match = FunctionV1 + "rfc822Name-match";
                public static readonly string OneAndOnly = FunctionV1 + "rfc822Name-one-and-only";
                public static readonly string RegexpMatch = FunctionV2 + "rfc822Name-regexp-match";
                public static readonly string SetEquals = FunctionV1 + "rfc822Name-set-equals";
                public static readonly string Subset = FunctionV1 + "rfc822Name-subset";
                public static readonly string Union = FunctionV1 + "rfc822Name-union";
            }

            public static class String
            {
                public static readonly string AtLeastOneMemberOf = FunctionV1 + "string-at-least-one-member-of";
                public static readonly string Bag = FunctionV1 + "string-bag";
                public static readonly string BagSize = FunctionV1 + "string-bag-size";
                public static readonly string Concatenate = FunctionV3 + "string-concatenate";
                public static readonly string Contains = FunctionV3 + "string-contains";
                public static readonly string EndsWith = FunctionV3 + "string-ends-with";
                public static readonly string Equal = FunctionV1 + "string-equal";
                public static readonly string EqualIgnoreCase = FunctionV3 + "string-equal-ignore-case";
                public static readonly string FromAnyUri = FunctionV3 + "string-from-anyURI";
                public static readonly string FromBoolean = FunctionV3 + "string-from-boolean";
                public static readonly string FromDate = FunctionV3 + "string-from-date";
                public static readonly string FromDateTime = FunctionV3 + "string-from-dateTime";
                public static readonly string FromDayTimeDuration = FunctionV3 + "string-from-dayTimeDuration";
                public static readonly string FromDnsName = FunctionV3 + "string-from-dnsName";
                public static readonly string FromDouble = FunctionV3 + "string-from-double";
                public static readonly string FromInteger = FunctionV3 + "string-from-integer";
                public static readonly string FromIpAddress = FunctionV3 + "string-from-ipAddress";
                public static readonly string FromRfc822Name = FunctionV3 + "string-from-rfc822Name";
                public static readonly string FromTime = FunctionV3 + "string-from-time";
                public static readonly string FromX500Name = FunctionV3 + "string-from-x500Name";
                public static readonly string FromYearMonthDuration = FunctionV3 + "string-from-yearMonthDuration";
                public static readonly string GreaterThan = FunctionV1 + "string-greater-than";
                public static readonly string GreaterThanOrEqual = GreaterThan + "-anyURI-or-equal";
                public static readonly string Intersection = FunctionV1 + "string-intersection";
                public static readonly string IsIn = FunctionV1 + "string-is-in";
                public static readonly string LessThan = FunctionV1 + "string-less-than";
                public static readonly string LessThanOrEqual = LessThan + "-anyURI-or-equal";
                public static readonly string NormalizeSpace = FunctionV1 + "string-normalize-space";
                public static readonly string NormalizeToLowerCase = FunctionV1 + "string-normalize-to-lower-case";
                public static readonly string OneAndOnly = FunctionV1 + "string-one-and-only";
                public static readonly string RegexpMatch = FunctionV1 + "string-regexp-match";
                public static readonly string SetEquals = FunctionV1 + "string-set-equals";
                public static readonly string StartsWith = FunctionV3 + "string-starts-with";
                public static readonly string Subset = FunctionV1 + "string-subset";
                public static readonly string Substring = FunctionV3 + "string-substring";
                public static readonly string Union = FunctionV1 + "string-union";
            }

            public static class Time
            {
                public static readonly string AtLeaseOneMemberOf = FunctionV1 + "time-at-least-one-member-of";
                public static readonly string Bag = FunctionV1 + "time-bag";
                public static readonly string BagSize = FunctionV1 + "time-bag-size";
                public static readonly string Equal = FunctionV1 + "time-equal";
                public static readonly string FromString = FunctionV3 + "time-from-string";
                public static readonly string GreaterThan = FunctionV1 + "time-greater-than";
                public static readonly string GreaterThanOrEqual = GreaterThan + "-anyURI-or-equal";
                public static readonly string InRange = FunctionV2 + "time-in-range";
                public static readonly string Intersection = FunctionV1 + "time-intersection";
                public static readonly string IsIn = FunctionV1 + "time-is-in";
                public static readonly string LessThan = FunctionV1 + "time-less-than";
                public static readonly string LessThanOrEqual = LessThan + "-anyURI-or-equal";
                public static readonly string OneAndOnly = FunctionV1 + "time-one-and-only";
                public static readonly string SetEquals = FunctionV1 + "time-set-equals";
                public static readonly string Subset = FunctionV1 + "time-subset";
                public static readonly string Union = FunctionV1 + "time-union";
            }
            public static class X500Name
            {
                public static readonly string AtLeaseOneMemberOf = FunctionV1 + "x500Name-at-least-one-member-of";
                public static readonly string Bag = FunctionV1 + "x500Name-bag";
                public static readonly string BagSize = FunctionV1 + "x500Name-bag-size";
                public static readonly string Equal = FunctionV1 + "x500Name-equal";
                public static readonly string FromString = FunctionV3 + "x500Name-from-string";
                public static readonly string Intersection = FunctionV1 + "x500Name-intersection";
                public static readonly string IsIn = FunctionV1 + "x500Name-is-in";
                public static readonly string Match = FunctionV1 + "x500Name-match";
                public static readonly string OneAndOnly = FunctionV1 + "x500Name-one-and-only";
                public static readonly string RegexpMatch = FunctionV2 + "x500Name-regexp-match";
                public static readonly string SetEquals = FunctionV1 + "x500Name-set-equals";
                public static readonly string Subset = FunctionV1 + "x500Name-subset";
                public static readonly string Union = FunctionV1 + "x500Name-union";
            }

            public static class XPathNode
            {
                public static readonly string Count = FunctionV3 + "xpath-node-count";
                public static readonly string Equal = FunctionV3 + "xpath-node-equal";
                public static readonly string Match = FunctionV3 + "xpath-node-match";
            }

            public static class YearMonthDuration
            {
                public static readonly string AtLeaseOneMemberOf = FunctionV3 + "yearMonthDuration-at-least-one-member-of";
                public static readonly string Bag = FunctionV3 + "yearMonthDuration-bag";
                public static readonly string BagSize = FunctionV3 + "yearMonthDuration-bag-size";
                public static readonly string Equal = FunctionV3 + "yearMonthDuration-equal";
                public static readonly string FromString = FunctionV3 + "yearMonthDuration-from-string";
                public static readonly string Intersection = FunctionV3 + "yearMonthDuration-intersection";
                public static readonly string IsIn = FunctionV3 + "yearMonthDuration-is-in";
                public static readonly string OneAndOnly = FunctionV3 + "yearMonthDuration-one-and-only";
                public static readonly string SetEquals = FunctionV3 + "yearMonthDuration-set-equals";
                public static readonly string Subset = FunctionV3 + "yearMonthDuration-subset";
                public static readonly string Union = FunctionV3 + "yearMonthDuration-union";
            }
        }

        public static class Algorithms
        {            
            private static readonly string AlgorithmDenyOverrides = "deny-overrides";
            private static readonly string AlgorithmPermitOverrides = "permit-overrides";
            private static readonly string AlgorithmFirstApplicable = "first-applicable";
            private static readonly string AlgorithmOnlyOneApplicable = "only-one-applicable";
            private static readonly string AlgorithmOrderedDenyOverrides = "ordered-deny-overrides";
            private static readonly string AlgorithmOrderedPermitOverrides = "ordered-permit-overrides";
            private static readonly string AlgorithmDenyUnlessPermit = "deny-unless-permit";
            private static readonly string AlgorithmPermitUnlessDeny = "permit-unless-deny";

            public static class RuleCombining
            {
                private static readonly string RuleCombiningToken = "rule-combining:";
                public static readonly string DenyOverrides = V3 + RuleCombiningToken + AlgorithmDenyOverrides;
                public static readonly string PermitOverrides = V3 + RuleCombiningToken + AlgorithmPermitOverrides;
                public static readonly string FirstApplicable = V3 + RuleCombiningToken + AlgorithmFirstApplicable;
                public static readonly string OnlyOneApplicable = V3 + RuleCombiningToken + AlgorithmOnlyOneApplicable;
                public static readonly string OrderedDenyOverrides = V3 + RuleCombiningToken + AlgorithmDenyOverrides;
                public static readonly string OrderedPermitOverrides = V3 + RuleCombiningToken + AlgorithmPermitOverrides;
                public static readonly string DenyUnlessPermit = V3 + RuleCombiningToken + AlgorithmDenyUnlessPermit;
                public static readonly string PermitUnlessDeny = V3 + RuleCombiningToken + AlgorithmPermitUnlessDeny;
            }

            public static class PolicyCombining
            {
                private static readonly string PolicyCombiningToken = "policy-combining:";
                public static readonly string DenyOverrides = V3 + PolicyCombiningToken + AlgorithmDenyOverrides;
                public static readonly string PermitOverrides = V3 + PolicyCombiningToken + AlgorithmPermitOverrides;
                public static readonly string FirstApplicable = V3 + PolicyCombiningToken + AlgorithmFirstApplicable;
                public static readonly string OnlyOneApplicable = V3 + PolicyCombiningToken + AlgorithmOnlyOneApplicable;
                public static readonly string OrderedDenyOverrides = V3 + PolicyCombiningToken + AlgorithmDenyOverrides;
                public static readonly string OrderedPermitOverrides = V3 + PolicyCombiningToken + AlgorithmPermitOverrides;
                public static readonly string DenyUnlessPermit = V3 + PolicyCombiningToken + AlgorithmDenyUnlessPermit;
                public static readonly string PermitUnlessDeny = V3 + PolicyCombiningToken + AlgorithmPermitUnlessDeny;
            }
        }

        /// <summary>
        /// <see cref="http://docs.oasis-open.org/xacml/3.0/xacml-3.0-core-spec-os-en.html#_Toc297001203"/>
        /// </summary>
        public static class DataTypes
        {
            private static readonly string XmlSchemaPrefix = "http://www.w3.org/2001/XMLSchema#";
            public static readonly string String = XmlSchemaPrefix + "string";
            public static readonly string Boolean = XmlSchemaPrefix + "boolean";
            public static readonly string Integer = XmlSchemaPrefix + "integer";
            public static readonly string Double = XmlSchemaPrefix + "double";
            public static readonly string Time = XmlSchemaPrefix + "time";
            public static readonly string DateTime = XmlSchemaPrefix + "dateTime";
            public static readonly string DayTimeDuration = XmlSchemaPrefix + "dayTimeDuration";
            public static readonly string YearMonthDuration = XmlSchemaPrefix + "yearMonthDuration";
            public static readonly string AnyUri = XmlSchemaPrefix + "anyURI";
            public static readonly string HexBinary = XmlSchemaPrefix + "hexBinary";
            public static readonly string Base64Binary = XmlSchemaPrefix + "base64Binary";

            private static readonly string DataType = "data-type:";
            public static readonly string Rfc822Name = V1 + DataType + "rfc822Name";
            public static readonly string X500Name = V1 + DataType + "x500Name";
            public static readonly string XPathExpression = V3 + DataType + "xpathExpression";
            public static readonly string IpAddress = V2 + DataType + "ipAddress";
            public static readonly string DnsName = V2 + DataType + "dnsName";
        }
    }
}