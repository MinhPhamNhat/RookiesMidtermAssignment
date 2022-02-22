
using System.ComponentModel;

namespace RookiesFashion.APIService.Constants;
public enum SystemRequirements
{
    IMAGE_MAX_COUNT = 2,
    [Description("image")]
    IMAGE_TYPE ,
    [Description(".png")]
    DEFAULT_IMAGE_EXTENSION
}