export interface ExamSessionResult {
    sessionResultId: number;
    sessionId: number;
    name: string;
    startDate:  Date;
    endDate: Date;
    score: number;
    maxScore: number;
}