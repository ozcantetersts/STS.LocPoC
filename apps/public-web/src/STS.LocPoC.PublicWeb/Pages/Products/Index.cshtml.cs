﻿using System.Collections.Generic;
using System.Threading.Tasks;
using STS.LocPoC.ProductService.Products;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace STS.LocPoC.PublicWeb.Pages.Products;

public class Index : AbpPageModel
{
    private readonly IProductPublicAppService _productPublicAppService;

    public Index(IProductPublicAppService productPublicAppService)
    {
        _productPublicAppService = productPublicAppService;
    }

    public List<ProductDto> Products { get; set; } = default!;

    public async Task OnGet()
    {
        Products = await _productPublicAppService.GetListAsync();
    }
}
