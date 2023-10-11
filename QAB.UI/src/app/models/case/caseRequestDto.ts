export default interface CaseRequestDto{
    title: string,
    description?: string,
    content: string,
    isActive: boolean,
    caseTypeId: number,
}