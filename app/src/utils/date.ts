export const formatDate = (date: Date | undefined): string | undefined => {
    if (!date) return undefined;

    const newDate = new Date(date);

    return `${newDate.getFullYear()}-${newDate.getMonth() + 1}-${newDate.getDate()} ${newDate.getHours()}:${newDate.getMinutes()}:${newDate.getSeconds()}`;
};
