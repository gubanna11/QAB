import CaseType from "../caseType";

export default interface CaseDto{
    id: number,
    authorId: string,
    title: string,
    description?: string,
    content: string,
    isActive: boolean,
    publishDate: string,
    publishTime: string,
    caseTypeId: number,
    caseType: CaseType
}