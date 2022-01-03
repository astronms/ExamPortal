export interface CourseModel {
    courseId: number;
    name: string;
    creationDate: string;
    sessions: string[];
    users: string[];
}

export interface CourseViewModel {
    id: number;
    no: number;
    title: string;
    creationDate: string;
    studentsNumber: number;
}