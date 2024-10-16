export type TMember = {
  id: string;
  name: string;
  nick: string;
  position: string;
  slogan: string;
  career: string;
  img: string;
  interview: boolean;
  url?: string;
};

export type TMemberData = {
  row: string;
  members: TMember[];
};
