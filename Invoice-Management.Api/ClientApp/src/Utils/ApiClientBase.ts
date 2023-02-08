import authService from "../components/api-authorization/AuthorizeService";

export class ApiClientBase {
    baseApiUrl: string ="https://localhost:44452/";

    protected async transformOptions(options : RequestInit): Promise<RequestInit>{
        const token = await authService.getAccessToken();
        options.headers = {...options.headers,authorization : `Bearer ${token}`};
        return Promise.resolve(options);
    }

    protected transformResult(url: string, respons: Response, processor: (respons:Response)=>any){
        return processor(respons);
    }

    protected getBaseUrl(defaultUrl: string, baseUrl?: string){
        return this.baseApiUrl;
    }
}