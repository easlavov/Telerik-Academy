namespace ComputerComponents.ComponentsFactory
{
    using System;

    internal static class VideoCardFactory
    {
        public static IVideoCard GetVideoCard(ComputerModel model)
        {
            IVideoCard newVideoCard;

            switch (model)
            {
                case ComputerModel.DellPersonal:
                    newVideoCard = new VideoCard(false);
                    return newVideoCard;
                case ComputerModel.DellLaptop:
                    newVideoCard = new VideoCard(false);
                    return newVideoCard;
                case ComputerModel.DellServer:
                    newVideoCard = new VideoCard(true);
                    return newVideoCard;
                case ComputerModel.HpPersonal:
                    newVideoCard = new VideoCard(false);
                    return newVideoCard;
                case ComputerModel.HpLaptop:
                    newVideoCard = new VideoCard(false);
                    return newVideoCard;
                case ComputerModel.HpServer:
                    newVideoCard = new VideoCard(true);
                    return newVideoCard;
                case ComputerModel.LenovoPersonal:
                    newVideoCard = new VideoCard(true);
                    return newVideoCard;
                case ComputerModel.LenovoLaptop:
                    newVideoCard = new VideoCard(false);
                    return newVideoCard;
                case ComputerModel.LenovoServer:
                    newVideoCard = new VideoCard(true);
                    return newVideoCard;
                default:
                    break;
            }

            throw new ArgumentException("Invalid model");
        }
    }
}
