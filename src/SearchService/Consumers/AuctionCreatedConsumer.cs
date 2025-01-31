using AutoMapper;
using Contracts;
using MassTransit;
using MongoDB.Entities;
using SearchService.Models;

namespace SearchService.Consumers;

public class AuctionCreatedConsumer : IConsumer<AuctionCreated>
{
    readonly IMapper mapper;
    
    public AuctionCreatedConsumer(IMapper mapper)
    {
        this.mapper = mapper;    
    }

    public async Task Consume(ConsumeContext<AuctionCreated> context)
    {
        var auction = context.Message;

        Console.WriteLine($"Consuming auction created: {auction.Id}");

        var item = mapper.Map<Item>(auction);

        await item.SaveAsync();
    }
}