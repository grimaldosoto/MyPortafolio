using Catalog.Application.Commons.Bases;
using Catalog.Application.Dtos.Request;
using Catalog.Application.Dtos.Response;
using Catalog.Infrastructure.Commons.Bases.Request;
using Catalog.Infrastructure.Commons.Bases.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Application.Interfaces
{
    public interface ITechnologyApplication
    {
        Task<BaseResponse<bool>> CreateTechnology(TechnologyRequestDto requestDto);
        Task<BaseResponse<BaseEntityResponse<TechnologyResponseDto>>> ReadTechnologies(BaseFiltersRequest filters);
        Task<BaseResponse<bool>> UpdateTechnology(int technologyId, TechnologyRequestDto requestDto); 
        Task<BaseResponse<bool>> DeleteTechnology(int technologyId);

        Task<BaseResponse<IEnumerable<TechnologySelectResponseDto>>> ListSelectTechnologies();
        Task<BaseResponse<TechnologyResponseDto>> TechnologyById(int technologyId);
    }

}
