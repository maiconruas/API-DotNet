﻿namespace ApiDotNet.Application.DTOs
{
	public class PagedResponseDTO<T>
	{
        public int TotalRegisters { get; private set; }
		public List<T> Data { get; private set; }

		public PagedResponseDTO(int totalRegisters, List<T> data)
		{
			TotalRegisters = totalRegisters;
			Data = data;
		}
	}
}
