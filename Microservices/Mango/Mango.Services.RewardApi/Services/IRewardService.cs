namespace Mango.Services.RewardApi.Services
{
    using Mango.Services.RewardsApi.Message;

    public interface IRewardService
    {
        Task UpdateRewards(RewardsMessage rewardsMessage);
    }
}
