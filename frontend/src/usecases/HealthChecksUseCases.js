import { GetHealthChecksInformationAsync } from "../repositories/HealthChecksRepository/HealthChecksRepository";

export async function GetHealthChecksAsync(){
    let result = await GetHealthChecksInformationAsync();
    return result;
}