export const desktopOS = [
  {
    label: 'Windows',
    value: 72.72,
    color: '#0088FE',
  },
  {
    label: 'OS X',
    value: 16.38,
    color: '#00C49F',
  },
  {
    label: 'Linux',
    value: 3.83,
    color: '#FFBB28',
  },
  {
    label: 'Chrome OS',
    value: 2.42,
    color: '#FF8042',
  },
  {
    label: 'Other',
    value: 4.65,
    color: '#EB5021',
  },
];

const normalize = (v: number, v2: number) =>
  Number.parseFloat(((v * v2) / 100).toFixed(2));

export const mobileAndDesktopOS = [
  ...desktopOS.map((v) => ({
    ...v,
    label: v.label === 'Other' ? 'Other (Desktop)' : v.label,
    value: normalize(v.value, 1),
  })),
];

export const valueFormatter = (item: { value: number }) => `${item.value}%`;
