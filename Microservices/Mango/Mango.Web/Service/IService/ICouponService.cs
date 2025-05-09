﻿namespace Mango.Web.Service.IService
{
    using Mango.Web.Models;

    public interface ICouponService
    {
        Task<ResponseDto?> GetCouponAsync(string couponCode);

        Task<ResponseDto?> GetAllCouponsAsync();

        Task<ResponseDto?> GetCouponByIdAsync(int id);

        Task<ResponseDto?> CreateCouponAsync(CouponDto couponDto);

        Task<ResponseDto?> UpdateCouponAsync(CouponDto couponDto);

        Task<ResponseDto?> DeleteCouponAsync(int id);
    }
}