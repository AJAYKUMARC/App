using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.Helpers
{
    public enum ConditionTypes
    {
        [StringValue("IS")]
        IS,

        [StringValue("IS_NOT")]
        IS_NOT,

        [StringValue("ANY_OF")]
        ANY_OF,

        [StringValue("ANY_OF_NOT")]
        ANY_OF_NOT,

        [StringValue("BETWEEN")]
        BETWEEN,

        [StringValue("BETWEEN_NOT")]
        BETWEEN_NOT,

        [StringValue("EQUAL")]
        EQUAL,

        [StringValue("EQUAL_NOT")]
        EQUAL_NOT,

        [StringValue("GREATER")]
        GREATER,

        [StringValue("GREATER_NOT")]
        GREATER_NOT,

        [StringValue("GREATER_OR_EQUAL")]
        GREATER_OR_EQUAL,

        [StringValue("GREATER_OR_EQUAL_NOT")]
        GREATER_OR_EQUAL_NOT,

        [StringValue("LESS")]
        LESS,

        [StringValue("LESS_NOT")]
        LESS_NOT,

        [StringValue("LESS_OR_EQUAL")]
        LESS_OR_EQUAL,

        [StringValue("LESS_OR_EQUAL_NOT")]
        LESS_OR_EQUAL_NOT,

        [StringValue("WITHIN")]
        WITHIN,

        [StringValue("WITHIN_NOT")]
        WITHIN_NOT,

        [StringValue("CONTAIN")]
        CONTAIN,

        [StringValue("CONTAIN_NOT")]
        CONTAIN_NOT,

        [StringValue("START_WITH")]
        START_WITH,

        [StringValue("START_WITH_NOT")]
        START_WITH_NOT,

        [StringValue("END_WITH")]
        END_WITH,

        [StringValue("END_WITH_NOT")]
        END_WITH_NOT,

        [StringValue("AFTER")]
        AFTER,

        [StringValue("AFTER_NOT")]
        AFTER_NOT,

        [StringValue("BEFORE")]
        BEFORE,

        [StringValue("BEFORE_NOT")]
        BEFORE_NOT,

        [StringValue("ON")]
        ON,

        [StringValue("ON_NOT")]
        ON_NOT,

        [StringValue("ON_OR_AFTER")]
        ON_OR_AFTER,

        [StringValue("ON_OR_AFTER_NOT")]
        ON_OR_AFTER_NOT,

        [StringValue("ON_OR_BEFORE")]
        ON_OR_BEFORE,

        [StringValue("ON_OR_BEFORE_NOT")]
        ON_OR_BEFORE_NOT,

        [StringValue("AND")]
        AND,

        [StringValue("WHERE")]
        WHERE,

        [StringValue(" ")]
        NULL
    }
}
