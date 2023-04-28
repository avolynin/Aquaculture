export type SideBarElement = {
    id: number;
    icon: any;
    text: string;
    link: string;
    children: SideBarElement[] | undefined;
}