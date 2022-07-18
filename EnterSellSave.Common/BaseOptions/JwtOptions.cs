namespace EnterSellSave.Common.BaseOptions
{
    public class JwtOptions
    {
        /// <summary>
        /// 密钥
        /// </summary> 
        public string SecKey { get; set; }


        /// <summary>
        ///过期时间
        /// </summary>
        public int ExpireSeconds { get; set; }

    }
}
